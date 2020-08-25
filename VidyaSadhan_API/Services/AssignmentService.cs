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
    public class AssignmentService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public AssignmentService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }


        public async Task<AssignmentsViewModel> GetAssignmentById(int assignmentId)
        {
            try
            {
                var result = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.AssignmentId == assignmentId).ConfigureAwait(false);
                return _map.Map<AssignmentsViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AssignmentsViewModel>> GetAssignmentByTutor(string UserId)
        {
            try
            {
                var result = await _dbContext.Assignments.Include(x=> x.StudentAssignments)
                    .ThenInclude(y=> y.Account).Where(z => z.InstructorId == UserId).ToListAsync().ConfigureAwait(false);
                return _map.Map<IEnumerable<AssignmentsViewModel>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<StudentAssignmentViewModel>> GetStudentAssignmentByTutor(string UserId)
        {
            try
            {
                var result = await _dbContext.StudentAssignments.Include(a => a.Assignment).Include(b => b.Account).Where(x => x.Assignment.InstructorId == UserId).ToListAsync().ConfigureAwait(false);
                return _map.Map<IEnumerable<StudentAssignmentViewModel>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<StudentAssignmentViewModel>> GetAssignmentByUser(string UserId)
        {
            try
            {
                var result = await _dbContext.StudentAssignments.Include(a => a.Assignment).Include(b=>b.Account).Where(x => x.UserId == UserId).ToListAsync().ConfigureAwait(false);
                return _map.Map<IEnumerable<StudentAssignmentViewModel>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveAssignment(AssignmentsViewModel Assignment)
        {
            try
            {
                _dbContext.Assignments.Add(_map.Map<Assignment>(Assignment));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAssignment(AssignmentsViewModel Assignment)
        {
            try
            {
                _dbContext.Assignments.Update(_map.Map<Assignment>(Assignment));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> AddUserToAssignment(StudentAssignmentViewModel Assignment)
        {
            try
            {
                _dbContext.StudentAssignments.Add(_map.Map<StudentAssignment>(Assignment));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
