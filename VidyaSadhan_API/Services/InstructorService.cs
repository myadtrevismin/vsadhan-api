using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;
using VidyaSadhan_API.Extensions;
using VidyaSadhan_API.Helpers;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class InstructorService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public InstructorService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<IEnumerable<InstructorViewModel>> GetAllInstructors()
        {
            try
            {
                var instructors = await _dbContext.Instructors.Include(x => x.Account).ThenInclude(A=> A.CourseAssignments).ThenInclude(b=> b.Course).ToListAsync();
                var instructorsView = _map.Map<IEnumerable<InstructorViewModel>>(instructors);
                if (instructorsView.Any())
                {
                    foreach (var item in instructorsView)
                    {
                        item.Name = string.Join(' ', item.Account.FirstName, item.Account.LastName);
                        item.Location = _map.Map<AddressViewModel>(_dbContext.AccountAddress?.FirstOrDefault(x => x.UserId == item.Account.Id));
                    }
                }
                return instructorsView;
            }
            catch (Exception ex)
            {
                var exception = new VSException();
                exception.Value = ex.Message;
                exception.StackTrace = ex.StackTrace;
                throw exception;
            }     
        }

        public async Task<InstructorViewModel> GetInstructorById(string UserId)
        {
            var instructor = await _dbContext.Instructors.FirstOrDefaultAsync(i=> i.UserId == UserId);
            _dbContext.Entry(instructor).Reference(y => y.Account).Load();
            return _map.Map<InstructorViewModel>(instructor);
        }


        public async Task<int> SaveInstructor(InstructorViewModel instructor)
        {
            _dbContext.Instructors.Add(_map.Map<Instructor>(instructor));
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateInstructor(InstructorViewModel instructor)
        {
            _dbContext.Instructors.Update(_map.Map<Instructor>(instructor));
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }


    }
}
