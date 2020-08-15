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
    [Route("api/demos")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly DemoService _DemoService;

        public DemoController(ILogger<DemoController> logger, DemoService DemoService)
        {
            _logger = logger;
            _DemoService = DemoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _DemoService.GetAll().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in get Demo", null);
                throw;
            }
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _DemoService.GetDemoById(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in get Demo", null);
                throw;
            }
        }

        [HttpGet]
        [Route("GetByUserId")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> GetByUser(string userId)
        {
            try
            {
                return Ok(await _DemoService.GetDemoByUserId(userId).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in get Demo", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Post([FromBody] DemoViewModel demo)
        {
            try
            {
                return Ok(await _DemoService.SaveDemo(demo).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in save Demo", null);
                throw;
            }
        }

        [HttpPost]
        [Route("request")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> CreateDemoRequest([FromBody] RequestViewModel demo)
        {
            try
            {
                return Ok(await _DemoService.RequestDemo(demo).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in save Demo", null);
                throw;
            }
        }

        [HttpPost]
        [Route("requests")]
        [ProducesResponseType(typeof(IEnumerable<RequestViewModel>), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> GetDemoRequests([FromBody] RequestViewModel demo)
        {
            try
            {
                return Ok(await _DemoService.GetDemoRequestsByUser(demo).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in save Demo", null);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Put(DemoViewModel demo)
        {
            try
            {
                return Ok(await _DemoService.UpdateDemo(demo).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in UpdateDemo", null);
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Demo"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> Delete(DemoViewModel demo)
        {
            try
            {
                return Ok(await _DemoService.DeleteDemo(demo).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in DeleteDemo", null);
                throw;
            }
        }
    }
}
