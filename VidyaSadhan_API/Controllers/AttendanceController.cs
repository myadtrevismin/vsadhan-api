using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidyaSadhan_API.Helpers;
using VidyaSadhan_API.Models;
using VidyaSadhan_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidyaSadhan_API.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ILogger<AttendanceController> _log;
        private readonly AttendanceService _attendanceService;

        public AttendanceController(ILogger<AttendanceController> log, AttendanceService attendanceService)
        {
            _log = log;
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AttendanceViewModel>), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("getbycourseid")]
        [ProducesResponseType(typeof(IEnumerable<AttendanceViewModel>), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> GetAttendanceByCourse(string id)
        {
            return Ok(await _attendanceService.GetAttendanceByCourse(id).ConfigureAwait(false));
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<AttendanceViewModel> value)
        {
            return Ok(await _attendanceService.Save(value).ConfigureAwait(false));
        }

        // PUT api/<AttendanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AttendanceViewModel value)
        {
        }

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
