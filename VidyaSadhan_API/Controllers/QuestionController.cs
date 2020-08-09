using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidyaSadhan_API.Helpers;
using VidyaSadhan_API.Models;
using VidyaSadhan_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidyaSadhan_API.Controllers
{
    [Route("api/Questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly QuestionService _QuestionService;

        public QuestionController(ILogger<QuestionController> logger, QuestionService QuestionService)
        {
            _logger = logger;
            _QuestionService = QuestionService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _QuestionService.GetQuestionById(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in get Question", null);
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Post([FromBody] QuestionViewModel question)
        {
            try
            {
                return Ok(await _QuestionService.SaveQuestion(question).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in save Question", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Put(QuestionViewModel Question)
        {
            try
            {
                return Ok(await _QuestionService.UpdateQuestion(Question).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in update question", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Question"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Delete(QuestionViewModel Question)
        {
            try
            {
                return Ok(await _QuestionService.DeleteQuestion(Question).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in delete question", null);
                throw;
            }
        }
    }
}
