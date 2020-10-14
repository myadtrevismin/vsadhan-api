using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidyaSadhan_API.Helpers;
using VidyaSadhan_API.Models;
using VidyaSadhan_API.Services;

namespace VidyaSadhan_API.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly AdminService _adminService;

        public AdminController(ILogger<AdminController> logger, AdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AddressViewModel>), 200)]
        [ProducesErrorResponseType(typeof(VSException))]
        public async Task<IActionResult> GetAdminDataCounts(string userId)
        {
            try
            {
                return Ok(await _adminService.GetAdminDataCount(userId).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured in users", null);
                throw;
            }
        }
    }
}
