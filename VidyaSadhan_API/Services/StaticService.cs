using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;
using VidyaSadhan_API.Extensions;
using VidyaSadhan_API.Helpers;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class StaticService
    {
        private VSDbContext _dbContext;
        IMapper _mapper;

        public StaticService(VSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _dbContext.Countries.ToList();
        }



        public IEnumerable<State> GetStates()
        {
            return _dbContext.States.ToList();
        }
        public StaticDataForSubjectsViewModel GetStaticDataForSubjects()
        {
            var result = new StaticDataForSubjectsViewModel();
            result.Groups = _dbContext.Groups.OrderBy(x => x.GroupName).ToList();
            result.Mediums = _dbContext.Mediums.OrderBy(x => x.MediumName).ToList();
            result.States = _dbContext.States.OrderBy(x => x.StateName).ToList();
            result.Subjects = _dbContext.Subjects.OrderBy(x => x.Name).ToList();
            result.Countries = _dbContext.Countries.OrderBy(x => x.CountryName).ToList();
            result.Boards = _dbContext.Boards.OrderBy(x => x.BoardName).ToList();
            return result;
        }

        public Statistics GetStatistics(string userId)
        {
            Statistics stats = new Statistics();
            var dbuser = _dbContext.Users.Include(x => x.Addresses).FirstOrDefault(a => a.Id == userId);
            switch (dbuser.Role)
            {
                case UserRoles.Student:
                    var events = _dbContext.Enrollments.Where(x => x.StudentID == userId);
                    stats.Events.Total = Convert.ToInt32(events?.Count());
                    stats.Events.Demos = Convert.ToInt32(events?.Count(x => x.Course.IsDemo));
                    stats.Events.Classes = Convert.ToInt32(events?.Count(x => !x.Course.IsDemo));
                    break;
                case UserRoles.Tutor:
                    var tutevents = _dbContext.CourseAssignments.Where(x => x.InstructorId == userId);
                    stats.Events.Total = Convert.ToInt32(tutevents?.Count());
                    stats.Events.Demos = Convert.ToInt32(tutevents?.Count(x => x.Course.IsDemo));
                    stats.Events.Classes = Convert.ToInt32(tutevents?.Count(x => !x.Course.IsDemo));
                    break;
                default:
                    break;
            }
            stats.Materials.Total = 0;
            stats.Progress.Total = 0;
            stats.Tutors.Total = _dbContext.Users.Count(x => x.Role == UserRoles.Tutor);
            stats.Profiles.Total = GetProfileCalc(dbuser);
            return stats;
        }

        private int GetProfileCalc(Account dbuser)
        {
            if (dbuser.Addresses.Any() == false)
            {
                return 0;
            }
            Dictionary<int, bool> calcs = new Dictionary<int, bool>();
            calcs.Add(1, dbuser.DateOfBirth.HasValue);
            calcs.Add(2, String.IsNullOrWhiteSpace(dbuser.Sex));
            var address = dbuser.Addresses.First();
            calcs.Add(3, String.IsNullOrWhiteSpace(address.Address1));
            calcs.Add(4, String.IsNullOrWhiteSpace(address.City));
            calcs.Add(5, String.IsNullOrWhiteSpace(address.CountryCd));
            calcs.Add(6, String.IsNullOrWhiteSpace(address.PinCode));
            calcs.Add(7, String.IsNullOrWhiteSpace(address.StateCd));
            if(dbuser.Role == UserRoles.Student)
            {
                var studentuser = _dbContext.Students.FirstOrDefault(x=> x.UserId == dbuser.Id);
                var academyType = Convert.ToInt32(studentuser?.AcademyTypeId);
                calcs.Add(8, Convert.ToInt32(academyType) > 0);
                if(academyType == 1)
                {
                    calcs.Add(9, String.IsNullOrWhiteSpace(studentuser.Medium));
                    calcs.Add(10, String.IsNullOrWhiteSpace(studentuser.Subjects));
                    calcs.Add(11, String.IsNullOrWhiteSpace(studentuser.Board));
                    calcs.Add(12, String.IsNullOrWhiteSpace(studentuser.Level));
                    calcs.Add(13, String.IsNullOrWhiteSpace(studentuser.Intersets));
                }
                else if(academyType == 2)
                {
                    calcs.Add(9, String.IsNullOrWhiteSpace(dbuser.NaCategory));
                    calcs.Add(10, String.IsNullOrWhiteSpace(dbuser.NaSubCategory));
                    calcs.Add(11, String.IsNullOrWhiteSpace(studentuser.Intersets));
                }
            }
            else
            {
                var tutortuser = _dbContext.Instructors.FirstOrDefault(x => x.UserId == dbuser.Id);
                var academyType = Convert.ToInt32(tutortuser?.AcademyTypeId);
                calcs.Add(8, String.IsNullOrWhiteSpace(tutortuser.HighestEducation));
                calcs.Add(9, String.IsNullOrWhiteSpace(tutortuser.Preference));
                calcs.Add(10, tutortuser.PreferredDistance > 0);
                calcs.Add(11, String.IsNullOrWhiteSpace(tutortuser.PreferredTimeSlot));
                calcs.Add(12, String.IsNullOrWhiteSpace(tutortuser.Currency));
                calcs.Add(13, tutortuser.HourlyRate > 0);
                calcs.Add(14, Convert.ToInt32(academyType) > 0);
                calcs.Add(15, String.IsNullOrWhiteSpace(tutortuser.IdType));
                calcs.Add(16, String.IsNullOrWhiteSpace(tutortuser.IdDoc));
                if (academyType == 1)
                {
                    calcs.Add(17, String.IsNullOrWhiteSpace(tutortuser.Medium));
                    calcs.Add(18, String.IsNullOrWhiteSpace(tutortuser.Subjects));
                    calcs.Add(19, String.IsNullOrWhiteSpace(tutortuser.Board));
                    calcs.Add(20, String.IsNullOrWhiteSpace(tutortuser.Level));
                    calcs.Add(21, String.IsNullOrWhiteSpace(tutortuser.Intersets));
                }
                else if (academyType == 2)
                {
                    calcs.Add(17, String.IsNullOrWhiteSpace(dbuser.NaCategory));
                    calcs.Add(18, String.IsNullOrWhiteSpace(dbuser.NaSubCategory));
                    calcs.Add(19, String.IsNullOrWhiteSpace(tutortuser.Intersets));
                    calcs.Add(20, String.IsNullOrWhiteSpace(dbuser.AgeGroup));
                    calcs.Add(21, String.IsNullOrWhiteSpace(dbuser.Certification));
                }
            }

            var count = calcs.Keys.Max();
            var values = calcs.Values.Count(x => x == false);
            var finalval = ((decimal)values / (decimal)count) * 100;
            return Convert.ToInt32(finalval);
        }

        public IEnumerable<NotificationModel> Notifications(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                var exception = new VSException();
                exception.Value = "User Info not available";
                throw exception;
            }

            return _mapper.Map<IEnumerable<NotificationModel>>(_dbContext.Notifications.Where(x => x.UserId == userId && x.Date.AddDays(5) < DateTime.Now));
        }
    }
}
