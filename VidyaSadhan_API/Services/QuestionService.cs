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
    public class QuestionService
    {
        private VSDbContext _dbContext;
        IMapper _map;

        public QuestionService(VSDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<QuestionViewModel> GetQuestionById(int questionId)
        {
            try
            {
                var result = await _dbContext.Questions.FirstOrDefaultAsync(x => x.QuestionId == questionId).ConfigureAwait(false);
                return _map.Map<QuestionViewModel>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveQuestion(QuestionViewModel question)
        {
            try
            {
                _dbContext.Questions.Add(_map.Map<Question>(question));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateQuestion(QuestionViewModel question)
        {
            try
            {
                _dbContext.Questions.Update(_map.Map<Question>(question));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteQuestion(QuestionViewModel question)
        {
            try
            {
                _dbContext.Questions.Remove(_map.Map<Question>(question));
                return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
