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
        private readonly IMilkingSlipDashboardService _milkingSlipDashboardService;
        private readonly IMilkCouponDashboardService _milkCouponDashboardService;
        public DashboardController(ICowDashboardService cowDashboardService
            ,IMilkingSlipDashboardService milkingSlipDashboardService
            ,IMilkCouponDashboardService milkCouponDashboardService)
        {
            _cowDashboardService = cowDashboardService;
            _milkingSlipDashboardService = milkingSlipDashboardService;
            _milkCouponDashboardService = milkCouponDashboardService;
        }

        [Route("dashboardCow/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetCowDashboardAsync(int id)
        {
            return Ok( await _cowDashboardService.GetCowDashboardAsync(id));
        }

        [Route("totalCow/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetCowTotalAsync(int id)
        {
            return Ok(await _cowDashboardService.GetCowTotalAsync(id));
        }

        [Route("milkingslip/{month}/{year}/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkingSlipDashboardAsync(int month, int year, int farmerId)
        {
            return Ok(await _milkingSlipDashboardService.GetMilkingSlipDashboardAsync(month,year,farmerId));
        }

        [Route("milkcoupon/{month}/{year}/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetMilkCouponDashboardAsync(int month, int year, int farmerId)
        {
            return Ok(await _milkCouponDashboardService.GetMilkCouponDashboardAsync(month, year, farmerId));
        }
    }
}