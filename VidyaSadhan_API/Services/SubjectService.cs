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
    public class SubjectService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public SubjectService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<SubjectViewModel> GetSubjectByUserId(int SubjectId)
        {
            try
            {
                var result = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.SubjectId == SubjectId).ConfigureAwait(false);
                return _map.Map<SubjectViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
