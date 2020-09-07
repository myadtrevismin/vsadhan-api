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
    [Route("api/Enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly ILogger<EnrollmentController> _logger;
        private readonly EnrollmentService _enrollmentService;

        public EnrollmentController(ILogger<EnrollmentController> logger, EnrollmentService enrollmentService)
        {
            _logger = logger;
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _enrollmentService.GetEnrollmentById(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in get Enrollment", null);
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
        public async Task<IActionResult> Post([FromBody] EnrolementViewModel Enrollment)
        {
            try
            {
                return Ok(await _enrollmentService.SaveEnrollment(Enrollment).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in save Enrollment", null);
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
        public async Task<IActionResult> Put(EnrolementViewModel Enrollment)
        {
            try
            {
                return Ok(await _enrollmentService.UpdateEnrollment(Enrollment).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in update Enrollment", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Enrollment"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Delete(EnrolementViewModel Enrollment)
        {
            try
            {
                return Ok(await _enrollmentService.DeleteEnrollment(Enrollment).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in delete Enrollment", null);
                throw;
            }
        }
    }
}
