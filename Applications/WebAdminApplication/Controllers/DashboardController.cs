using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain.Dashboard.IServices;
using ApplicationDomain.Dashboard.Models.Cows;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAdminApplication.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly ICowDashboardService _cowDashboardService;
        public DashboardController(ICowDashboardService cowDashboardService)
        {
            _cowDashboardService = cowDashboardService;
        }

        [Route("dashboardCow/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCowDashboardAsync(int id)
        {
            return Ok( await _cowDashboardService.GetCowDashboardAsync(id));
        }

        [Route("totalCow/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCowTotalAsync(int id)
        {
            return Ok(await _cowDashboardService.GetCowTotalAsync(id));
        }

    }
}