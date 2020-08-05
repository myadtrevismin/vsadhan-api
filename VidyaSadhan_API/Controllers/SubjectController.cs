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
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly SubjectService _subjectService;

        public SubjectController(ILogger<AddressController> logger, SubjectService subjectService)
        {
            _logger = logger;
            _subjectService = subjectService;
        }

        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _subjectService.GetSubjectByUserId(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in get Subject", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Post([FromBody] SubjectViewModel subject)
        {
            try
            {
                return Ok(await _subjectService.SaveSubject(subject).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in save subject", null);
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
        public async Task<IActionResult> Put(SubjectViewModel subject)
        {
            try
            {
                return Ok(await _subjectService.UpdateSubject(subject).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in users", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Delete(SubjectViewModel subject)
        {
            try
            {
                return Ok(await _subjectService.DeleteSubject(subject).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in users", null);
                throw;
            }
        }
    }
}
