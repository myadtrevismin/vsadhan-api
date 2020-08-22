using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidyaSadhan_API.Models;
using VidyaSadhan_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidyaSadhan_API.Controllers
{
    [Route("api/assignments")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ILogger<AssignmentsController> _logger;
        private readonly AssignmentService _assignmentService;

        public AssignmentsController(ILogger<AssignmentsController> logger, AssignmentService assignmentService)
        {
            _logger = logger;
            _assignmentService = assignmentService;
        }

        // GET: api/<AssignmentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AssignmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentById(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }          
        }

        [Route("student")]
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentByUser(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [Route("tutor")]
        [HttpGet]
        public async Task<IActionResult> GetTutorAssignments(string id)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentByTutor(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [Route("studentassignments/tutor")]
        [HttpGet]
        public async Task<IActionResult> GetTutorStudentAssignments(string id)
        {
            try
            {
                return Ok(await _assignmentService.GetStudentAssignmentByTutor(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        // POST api/<AssignmentsController>
        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AssignmentsViewModel assignment)
        {
            try
            {
                return Ok(await _assignmentService.SaveAssignment(assignment).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Put([FromBody] AssignmentsViewModel assignment)
        {
            try
            {
                return Ok(await _assignmentService.UpdateAssignment(assignment).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        [Route("addusers")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentAssignmentViewModel assignment)
        {
            try
            {
                return Ok(await _assignmentService.AddUserToAssignment(assignment).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
