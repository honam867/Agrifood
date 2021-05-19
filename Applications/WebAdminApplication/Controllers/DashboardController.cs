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
        private readonly IDashboardCowService _dashboardCowService;
        private readonly IDashboardMilkingSlipService _dashboardMilkingSlipService;
        private readonly IDashboardMilkCouponService _dashboardMilkCouponService;
        public DashboardController(IDashboardCowService dashboardCowService
            ,IDashboardMilkingSlipService dashboardMilkingSlipService
            ,IDashboardMilkCouponService dashboardMilkCouponService)
        {
            _dashboardCowService = dashboardCowService;
            _dashboardMilkingSlipService = dashboardMilkingSlipService;
            _dashboardMilkCouponService = dashboardMilkCouponService;
        }

        [Route("dashboardCow")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardCowAsync()
        {
            return Ok(await _dashboardCowService.GetDashboardCowAsync());
        }

        [Route("dashboardCow/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardCowByFarmerIdAsync(int id)
        {
            return Ok( await _dashboardCowService.GetDashboardCowByFarmerIdAsync(id));
        }

        [Route("dashboardTotalCow")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardTotalCowAsync()
        {
            return Ok(await _dashboardCowService.GetDashboardTotalCowAsync());
        }

        [Route("dashboardTotalCow/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardTotalCowByFarmerIdAsync(int id)
        {
            return Ok(await _dashboardCowService.GetDashboardTotalCowByFarmerIdAsync(id));
        }

        [Route("milkingslip/{dayFrom}/{dayTo}}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkingSlipByDayfromtoAsync(DateTime dayFrom, DateTime dayTo)
        {
            return Ok(await _dashboardMilkingSlipService.GetDashboardMilkingSlipByDayfromtoAsync(dayFrom, dayTo));
        }

        [Route("milkingslip/{dayFrom}/{dayTo}/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId)
        {
            return Ok(await _dashboardMilkingSlipService.GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(dayFrom,dayTo,farmerId));
        }

        [Route("milkcoupon/{dayFrom}/{dayTo}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkCouponByDayfromtoAsync(DateTime dayFrom, DateTime dayTo)
        {
            return Ok(await _dashboardMilkCouponService.GetDashboardMilkCouponByDayfromtoAsync(dayFrom, dayTo));
        }

        [Route("milkcoupon/{dayFrom}/{dayTo}/{farmerId}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId)
        {
            return Ok(await _dashboardMilkCouponService.GetDashboardMilkCouponByDayfromtoFarmerIdAsync(dayFrom, dayTo, farmerId));
        }
    }
}