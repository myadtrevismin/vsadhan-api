﻿using AutoMapper;
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
    public class DemoService
    {
        private VSDbContext _dbContext;
        private ICalendarService _calendarService;
        private readonly ConfigSettings _configsetting;
        private readonly UserService _userService;
        IMapper _map;

        public DemoService(VSDbContext dbContext, ICalendarService calendarService,
            IOptionsMonitor<ConfigSettings> optionsMonitor, IMapper map, UserService userService)
        {
            _dbContext = dbContext;
            _calendarService = calendarService;
            _configsetting = optionsMonitor.CurrentValue;
            _userService = userService;
            _map = map;
        }

        public async Task<IEnumerable<DemoViewModel>> GetAll()
        {
            try
            {
                var result = await _dbContext.Demos.Where(x=>x.IsDemo).ToListAsync().ConfigureAwait(false);
                return _map.Map<IEnumerable<DemoViewModel>>(result).OrderByDescending(x=>x.StartDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DemoViewModel> GetDemoById(string demoId)
        {
            try
            {
                var result = _map.Map<DemoViewModel>(await _dbContext.Demos.Include(x=> x.Enrollments).ThenInclude(y=> y.Student).FirstOrDefaultAsync(x => x.CourseId == demoId).ConfigureAwait(false));
                if(result != null)
                {
                    GetGoogleCalendarEvent(new List<DemoViewModel> { result });
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DemoViewModel>> GetDemoByUserId(string userId)
        {
            try
            {
                IEnumerable<Demo> demos = null;
                var user = _userService.GetUserById(userId);
                if (user.Role == UserRoles.Student)
                {
                    demos = await _dbContext.Demos.Include(x => x.Enrollments).ThenInclude(a => a.Student).Include(x => x.CourseAssignments)
                        .Where(y => y.Enrollments.Any(z => z.StudentID == userId)  && !y.ValidEndDate.HasValue).ToListAsync();
                }
                else if (user.Role == UserRoles.Tutor)
                {
                    demos = await _dbContext.Demos.Include(x => x.Enrollments).ThenInclude(a => a.Student).Include(x => x.CourseAssignments)
                       .Where(y => y.CourseAssignments.Any(a => a.InstructorId == userId) && !y.ValidEndDate.HasValue).ToListAsync();
                }

                var resultView = _map.Map<IEnumerable<DemoViewModel>>(demos);
                GetGoogleCalendarEvent(resultView);
                return resultView.OrderByDescending(x=>x.StartDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetGoogleCalendarEvent(IEnumerable<DemoViewModel> resultView)
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

        public async Task<int> SaveDemo(DemoViewModel demo)
        {
            try
            {
                var calendar = _calendarService.Initialize(demo.CalendarEvent.UserEmail.IsNullOrWhiteSpace() ? _configsetting.AdminEmail : demo.CalendarEvent.UserEmail);
                var cEvent = _calendarService.CreateEvent(calendar, demo.CalendarEvent);
                demo.ExternalCourseId = cEvent.Id;
                demo.CourseId = Guid.NewGuid().ToString();
                foreach (var item in demo.CourseAssignments)
                {
                    item.CourseId = demo.CourseId;
                }

                foreach (var item in demo.Enrollments)
                {
                    item.CourseId = demo.CourseId;
                }

                _dbContext.Demos.Add(_map.Map<Demo>(demo));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<int> UpdateDemo(DemoViewModel demo)
        {
            try
            {
                _dbContext.Demos.Update(_map.Map<Demo>(demo));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteDemo(DemoViewModel demo)
        {
            try
            {
                _dbContext.Demos.Remove(_map.Map<Demo>(demo));
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
                var tutor = _userService.GetUserById(request.TutorId);
                var student = _userService.GetUserById(request.StudentId);
                _dbContext.Requests.Add(_map.Map<Request>(request));
                _dbContext.Notifications.Add(new Notification
                {
                    Title = "Demo/Course",
                    Message = "New Request from" + student.FirstName + " " + student.LastName,
                    UserId = tutor.Id,
                    OriginId = student.Id,
                    Date = DateTime.Now,
                });
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
                    requests = _map.Map<List<RequestViewModel>>(await _dbContext.Requests.Include(x=>x.Student)
                        .Where(x => x.TutorId == request.TutorId).ToListAsync());
                   
                }
                if (!string.IsNullOrWhiteSpace(request.StudentId))
                {
                    requests = _map.Map<List<RequestViewModel>>(await _dbContext.Requests.Include(x => x.Tutor)
                        .Where(x => x.StudentId == request.StudentId).ToListAsync());
                }
                requests.ForEach(x => { 
                    x.Status = _dbContext.Enrollments?.Any(y => y.CourseId == x.Slot && y.StudentID == x.StudentId) == false ? Status.Request : _dbContext.Enrollments.FirstOrDefault(y => y.CourseId == x.Slot && y.StudentID == x.StudentId).Status;
                    x.Course = _map.Map<DemoViewModel>(_dbContext.Demos.FirstOrDefault(y => y.CourseId == x.Slot));
                });

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
