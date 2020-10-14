using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MimeKit.Encodings;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;
using VidyaSadhan_API.Extensions;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class AdminService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public AdminService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }


        public async Task<AdminViewModel> GetAdminDataCount(string userId)
        {
            try
            {
                AdminViewModel adminData = new AdminViewModel();
                var result = await _dbContext.AccountAddress.FirstOrDefaultAsync(x => x.UserId == userId).ConfigureAwait(false);
                adminData.ClassesOrDemos = await _dbContext.Courses.CountAsync().ConfigureAwait(false);

                var roleTutor = await _dbContext.Roles.SingleAsync(x => x.NormalizedName == "TUTOR").ConfigureAwait(false);
                adminData.Tutors = await _dbContext.UserRoles.Where(x => x.RoleId == roleTutor.Id).CountAsync().ConfigureAwait(false);

                var roleStudent = await _dbContext.Roles.SingleAsync(x => x.NormalizedName == "STUDENT").ConfigureAwait(false);
                adminData.Students = await _dbContext.UserRoles.Where(x => x.RoleId == roleStudent.Id).CountAsync().ConfigureAwait(false);

                var roleParent = await _dbContext.Roles.SingleAsync(x => x.NormalizedName == "PARENT").ConfigureAwait(false);
                adminData.Parents = await _dbContext.UserRoles.Where(x => x.RoleId == roleParent.Id).CountAsync().ConfigureAwait(false);

                adminData.TotalRevinue = 1000;

                adminData.NewRequests = await _dbContext.Requests.Where(x => x.Date > DateTime.Today.AddDays(2)).CountAsync().ConfigureAwait(false);

                return adminData;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
