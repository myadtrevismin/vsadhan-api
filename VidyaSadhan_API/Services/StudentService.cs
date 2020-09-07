using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;
using VidyaSadhan_API.Extensions;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class StudentService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public StudentService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllStudents()
        {
            var students = await _dbContext.Students.Include(x => x.Account).ToListAsync();
            return _map.Map<IEnumerable<StudentViewModel>>(students);
        }

        public async Task<StudentViewModel> GetStudentById(string UserId)
        {
            var instructor = await _dbContext.Students.FirstOrDefaultAsync(i => i.UserId == UserId);
            _dbContext.Entry(instructor).Reference(y => y.Account).Load();
            return _map.Map<StudentViewModel>(instructor);
        }

        public async Task<IEnumerable<EnrolementViewModel>> GetStudentsByTutorId(string UserId)
        {
            var enrollments = await _dbContext.Enrollments.Include(y=> y.Course).Include(y=> y.Student).Where(i => i.Course.CourseAssignments.Any(y=> y.InstructorId == UserId)).ToListAsync(); 
            var studentView = _map.Map<IEnumerable<EnrolementViewModel>>(enrollments);
            var resultset = studentView.GroupBy(y => new { y.StudentID, y.CourseId }).Select(x => new EnrolementViewModel
            {
                Name = x.First().Student.FirstName + " " + x.First().Student.LastName,
                Student = x.First().Student,
                StudentID = x.Key.StudentID,
                CourseId = x.Key.CourseId,
                Course = x.First().Course,
                ClassCount = x.Count(),
                PaymentAmount = x.Sum(a=> a.PaymentAmount),
                Status = x.First().Status,
                PaymentStatus = "Pending",
            });
            return resultset;
        }


        public async Task<int> SaveStudent(StudentViewModel instructor)
        {
            _dbContext.Students.Add(_map.Map<Student>(instructor));
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateEnrollment(EnrolementViewModel enrollment)
        {
            var enrollmentselected = _dbContext.Enrollments.FirstOrDefault(x => x.CourseId == enrollment.CourseId && x.StudentID == enrollment.StudentID);
            if(enrollmentselected == null)
            {
                _dbContext.Enrollments.Add(_map.Map<Enrollment>(enrollment));
                _dbContext.Notifications.Add(new Notification
                {
                    Title = "Demo/Course",
                    Message = "Enrolled into" + enrollment.Course.Title + " " + (enrollment.Course.IsDemo ? "Demo" : "Course"),
                    UserId = enrollment.StudentID,
                    OriginId = enrollment.Course.CourseAssignments.FirstOrDefault()?.InstructorId,
                    Date = DateTime.Now,
                });
            }
            else
            {
                enrollmentselected.Status = enrollment.Status;
                _dbContext.Notifications.Add(new Notification
                {
                    Title = "Demo/Course",
                    Message = "Enrollment into" + enrollment.Course.Title + " " + (enrollment.Course.IsDemo ? "Demo" : "Course") + "has been changed",
                    UserId = enrollment.StudentID,
                    OriginId = enrollment.Course.CourseAssignments.FirstOrDefault()?.InstructorId,
                    Date = DateTime.Now,
                });
            }

            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }


        public async Task<int> UpdateStudent(StudentViewModel instructor)
        {
            _dbContext.Students.Update(_map.Map<Student>(instructor));
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
