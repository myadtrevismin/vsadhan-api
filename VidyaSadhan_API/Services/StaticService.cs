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
            result.Groups = _dbContext.Groups.OrderBy(x=>x.GroupName).ToList();
            result.Mediums = _dbContext.Mediums.OrderBy(x => x.MediumName).ToList();
            result.States = _dbContext.States.OrderBy(x => x.StateName).ToList();
            result.Subjects = _dbContext.Subjects.OrderBy(x => x.Name).ToList();
            result.Countries = _dbContext.Countries.OrderBy(x => x.CountryName).ToList();
            result.Boards = _dbContext.Boards.OrderBy(x => x.BoardName).ToList();
            return result;
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
