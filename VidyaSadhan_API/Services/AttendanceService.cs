using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
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
    public class AttendanceService
    {
        private VSDbContext _dbContext;
        private readonly ConfigSettings _configsetting;
        IMapper _map;

        public AttendanceService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<IEnumerable<AttendanceViewModel>> GetAttendanceByCourse(string id)
        {
            try
            {
                var attendances = await _dbContext.Attendances.Include(x=>x.Course).Include(x=> x.User)?.Where(x => x.CourseId == id).ToListAsync();
                var attendanceView = _map.Map<List<AttendanceViewModel>>(attendances);
                if (attendanceView.Any())
                {
                    attendanceView.ForEach(x => { x.Address = x.Course.LocationName; x.Name = x.User.LastName  + " " + x.User.FirstName; } );
                }
                return attendanceView;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> Save(IEnumerable<AttendanceViewModel> attendances)
        {
            try
            {
                _dbContext.Attendances.AddRange(_map.Map<IEnumerable<Attendance>>(attendances));
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
