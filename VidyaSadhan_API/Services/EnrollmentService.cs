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
    public class EnrollmentService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public EnrollmentService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<EnrolementViewModel> GetEnrollmentById(int enrollmentId)
        {
            try
            {
                var result = await _dbContext.Enrollments.FirstOrDefaultAsync(x => x.EnrollementId == enrollmentId).ConfigureAwait(false);
                return _map.Map<EnrolementViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveEnrollment(EnrolementViewModel enrollment)
        {
            try
            {
                _dbContext.Enrollments.Add(_map.Map<Enrollment>(enrollment));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateEnrollment(EnrolementViewModel enrollment)
        {
            try
            {
                _dbContext.Enrollments.Update(_map.Map<Enrollment>(enrollment));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteEnrollment(EnrolementViewModel enrollment)
        {
            try
            {
                _dbContext.Enrollments.Remove(_map.Map<Enrollment>(enrollment));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
