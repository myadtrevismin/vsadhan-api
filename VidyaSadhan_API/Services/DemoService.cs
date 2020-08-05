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
    public class DemoService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public DemoService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<IEnumerable<DemoViewModel>> GetAll()
        {
            try
            {
                var result = await _dbContext.Demos.ToListAsync().ConfigureAwait(false);
                return _map.Map<IEnumerable<DemoViewModel>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DemoViewModel> GetDemoById(int demoId)
        {
            try
            {
                var result = await _dbContext.Demos.FirstOrDefaultAsync(x => x.CourseId == demoId).ConfigureAwait(false);
                return _map.Map<DemoViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveDemo(DemoViewModel Demo)
        {
            try
            {
                _dbContext.Demos.Add(_map.Map<Demo>(Demo));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<int> UpdateDemo(DemoViewModel Demo)
        {
            try
            {
                _dbContext.Demos.Update(_map.Map<Demo>(Demo));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteDemo(DemoViewModel Demo)
        {
            try
            {
                _dbContext.Demos.Remove(_map.Map<Demo>(Demo));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
