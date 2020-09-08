using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaSadhan_API.Entities;
using VidyaSadhan_API.Extensions;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class StaticService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public StaticService(VSDbContext dbContext)
        {
            _dbContext = dbContext;
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
            result.Groups = _dbContext.Groups.ToList();
            result.Mediums = _dbContext.Mediums.ToList();
            result.States = _dbContext.States.ToList();
            result.Subjects = _dbContext.Subjects.ToList();
            return result;
        }
    }
}
