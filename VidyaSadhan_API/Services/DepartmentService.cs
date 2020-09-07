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
    public class DepartmentService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public DepartmentService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<DepartmentViewModel> GetDepartmentById(int departmentId)
        {
            try
            {
                var result = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentID == departmentId).ConfigureAwait(false);
                return _map.Map<DepartmentViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveDepartment(DepartmentViewModel department)
        {
            try
            {
                _dbContext.Departments.Add(_map.Map<Department>(department));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateDepartment(DepartmentViewModel department)
        {
            try
            {
                _dbContext.Departments.Update(_map.Map<Department>(department));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteDepartment(DepartmentViewModel department)
        {
            try
            {
                _dbContext.Departments.Remove(_map.Map<Department>(department));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
