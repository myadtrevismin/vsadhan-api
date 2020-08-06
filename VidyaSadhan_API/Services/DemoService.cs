using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
        IMapper _map;

        public DemoService(VSDbContext dbContext,ICalendarService calendarService,
            IOptionsMonitor<ConfigSettings> optionsMonitor,IMapper map)
        {
            _dbContext = dbContext;
            _calendarService = calendarService;
            _configsetting = optionsMonitor.CurrentValue;
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

        public async Task<int> SaveDemo(DemoViewModel demo)
        {
            try
            {
                var calendar = _calendarService.Initialize(demo.CalendarEvent.UserEmail.IsNullOrWhiteSpace() ? _configsetting.AdminEmail : demo.CalendarEvent.UserEmail);
                var cEvent = _calendarService.CreateEvent(calendar, demo.CalendarEvent);
                demo.ExternalCourseId = cEvent.Id;
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
    }
}
