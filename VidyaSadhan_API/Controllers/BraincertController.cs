using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidyaSadhan_API.Models;
using VidyaSadhan_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidyaSadhan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BraincertController : ControllerBase
    {
        private readonly BrainCertService _brainCertService;
        public BraincertController(BrainCertService brainCertService)
        {
            _brainCertService = brainCertService;
        }


        // GET: api/<BraincertController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _brainCertService.GetClassList().ConfigureAwait(false));
        }

        // GET api/<BraincertController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BraincertController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClassRequestModel_B request)
        {
           return Ok(await _brainCertService.CreateClass(request).ConfigureAwait(false));
        }

        // PUT api/<BraincertController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BraincertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
