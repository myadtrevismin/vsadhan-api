using AutoMapper;
using Google.Apis.Calendar.v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;
using VidyaSadhan_API.Extensions;
using VidyaSadhan_API.Helpers;
using VidyaSadhan_API.Models;
using VS_GAPI.Services;
using VS_Models;

namespace VidyaSadhan_API.Services
{
    public class CourseServiceV
    {
        private VSDbContext _dbContext;
        private ICalendarService _calendarService;
        private readonly ConfigSettings _configsetting;
        private readonly UserService _userService;
        IMapper _map;

        public CourseServiceV(VSDbContext dbContext, ICalendarService calendarService,
            IOptionsMonitor<ConfigSettings> optionsMonitor, IMapper map, UserService userService)
        {
            _dbContext = dbContext;
            _calendarService = calendarService;
            _configsetting = optionsMonitor.CurrentValue;
            _userService = userService;
            _map = map;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAll()
        {
            try
            {
                var result = await _dbContext.Courses.Where(x=> !x.IsDemo).ToListAsync().ConfigureAwait(false);
                return _map.Map<IEnumerable<CourseViewModel>>(result).OrderByDescending(x=>x.StartDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CourseViewModel> GetCourseById(string courseId)
        {
            try
            {
                var result = _map.Map<CourseViewModel>(await _dbContext.Courses.Include(x=> x.Enrollments).ThenInclude(y=> y.Student).FirstOrDefaultAsync(x => x.CourseId == courseId).ConfigureAwait(false));
                if(result != null)
                {
                    GetGoogleCalendarEvent(new List<CourseViewModel> { result });
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CourseViewModel>> GetCourseByUserId(string userId)
        {
            try
            {
                IEnumerable<Course> courses = null;
                var user = _userService.GetUserById(userId);
                if (user.Role == UserRoles.Student)
                {
                    courses = await _dbContext.Courses.Include(x => x.Enrollments).Include(x => x.CourseAssignments)
                        .Where(y => y.Enrollments.Any(z => z.StudentID == userId) && !y.IsDemo).ToListAsync();
                }
                else if (user.Role == UserRoles.Tutor)
                {
                    courses = await _dbContext.Courses.Include(x => x.Enrollments).Include(x => x.CourseAssignments)
                       .Where(y => y.CourseAssignments.Any(a => a.InstructorId == userId) && !y.IsDemo).ToListAsync();
                }

                var resultView = _map.Map<IEnumerable<CourseViewModel>>(courses);
                GetGoogleCalendarEvent(resultView);
                return resultView.OrderByDescending(x=>x.StartDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetGoogleCalendarEvent(IEnumerable<CourseViewModel> resultView)
        {
            var events = GetCalendarEvents(_configsetting.AdminEmail);
            foreach (var item in resultView)
            {
                Event cEvent = events.Items.FirstOrDefault(x => x.Id == item.ExternalCourseId);
                if (cEvent != null)
                {
                    item.CalendarEvent = new CalendarEvent
                    {
                        Location = cEvent.Location,
                        Attendees = cEvent.Attendees.Select(x => x.Email),
                        Description = cEvent.Description,
                        Start = cEvent.Start.DateTime.Value,
                        End = cEvent.End.DateTime.Value,
                        Organizer = cEvent.Organizer.Email,
                        Summary = cEvent.Organizer.DisplayName,
                        VideoLink = cEvent.HangoutLink
                    };
                }
            }
        }

        private Events GetCalendarEvents(string useremail)
        {
            var calendar = _calendarService.Initialize(useremail);
            return _calendarService.ListEvents(calendar);
        }

        public async Task<int> SaveCourse(CourseViewModel course)
        {
            try
            {
                var calendar = _calendarService.Initialize(course.CalendarEvent.UserEmail.IsNullOrWhiteSpace() ? _configsetting.AdminEmail : course.CalendarEvent.UserEmail);
                var cEvent = _calendarService.CreateEvent(calendar, course.CalendarEvent);
                course.ExternalCourseId = cEvent.Id;
                course.IsDemo = true;
                course.CourseId = Guid.NewGuid().ToString();
                foreach (var item in course.CourseAssignments)
                {
                    item.CourseId = course.CourseId;
                }

                foreach (var item in course.Enrollments)
                {
                    item.CourseId = course.CourseId;
                }
                _dbContext.Courses.Add(_map.Map<Course>(course));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<int> UpdateDemo(CourseViewModel course)
        {
            try
            {
                _dbContext.Courses.Update(_map.Map<Course>(course));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteDemo(CourseViewModel demo)
        {
            try
            {
                _dbContext.Courses.Remove(_map.Map<Course>(demo));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RequestDemo(RequestViewModel request)
        {
            try
            {
                _dbContext.Requests.Add(_map.Map<Request>(request));
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = new VSException(ex.Message);
                exception.Value = ex.StackTrace;
                throw;
            }
        }

        public async Task<IEnumerable<RequestViewModel>> GetDemoRequestsByUser(RequestViewModel request)
        {
            try
            {
                List<RequestViewModel> requests = new List<RequestViewModel>();
                if (!string.IsNullOrWhiteSpace(request.TutorId))
                {
                    requests = _map.Map<List<RequestViewModel>>(await _dbContext.Requests.Include(x=> x.Tutor).Include(x=>x.Student)
                        .Where(x => x.TutorId == request.TutorId).ToListAsync());
                   
                }
                if (!string.IsNullOrWhiteSpace(request.StudentId))
                {
                    requests = _map.Map<List<RequestViewModel>>(await _dbContext.Requests.Include(x => x.Tutor).Include(x => x.Student)
                        .Where(x => x.StudentId == request.StudentId).ToListAsync());
                }
                requests.ForEach(x => { x.Status = _dbContext.Enrollments?.Any(y => y.CourseId == x.Slot && y.StudentID == x.StudentId) == false ? Status.Request : _dbContext.Enrollments.FirstOrDefault(y => y.CourseId == x.Slot && y.StudentID == x.StudentId).Status; });

                return requests;
            }
            catch (Exception ex)
            {
                var exception = new VSException(ex.Message);
                exception.Value = ex.StackTrace;
                throw;
            }
        }
    }
}
