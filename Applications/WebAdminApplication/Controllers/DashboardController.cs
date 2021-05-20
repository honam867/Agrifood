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
        private readonly IDashboardOrderFoodService _dashboardOrderFoodService;
        private readonly IDashboardUsingService _dashboardUsingService;
        public DashboardController(IDashboardCowService dashboardCowService
            ,IDashboardMilkingSlipService dashboardMilkingSlipService
            ,IDashboardMilkCouponService dashboardMilkCouponService
            ,IDashboardOrderFoodService dashboardOrderFoodService
            ,IDashboardUsingService dashboardUsingService)
        {
            _dashboardCowService = dashboardCowService;
            _dashboardMilkingSlipService = dashboardMilkingSlipService;
            _dashboardMilkCouponService = dashboardMilkCouponService;
            _dashboardOrderFoodService = dashboardOrderFoodService;
            _dashboardUsingService = dashboardUsingService;
        }

        [Route("dashboardCow")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardCowAsync()
        {
            return Ok(await _dashboardCowService.GetDashboardCowAsync());
        }

        [Route("dashboardCow/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCowDashboardAsync(int id)
        {
            return Ok( await _dashboardCowService.GetDashboardCowByFarmerIdAsync(id));
        }

        [Route("dashboardTotalCow")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardTotalCowAsync()
        {
            return Ok(await _dashboardCowService.GetDashboardTotalCowAsync());
        }

        [Route("dashboardTotalCow/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCowTotalAsync(int id)
        {
            return Ok(await _dashboardCowService.GetDashboardTotalCowByFarmerIdAsync(id));
        }

        [Route("milkingslip/{from}/{to}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkingSlipByDayfromtoAsync(int from, int to)
        {
            return Ok(await _dashboardMilkingSlipService.GetDashboardMilkingSlipByDayfromtoAsync(from, to));
        }

        [Route("milkingslip/{from}/{to}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(int from, int to, int id)
        {
            return Ok(await _dashboardMilkingSlipService.GetDashboardMilkingSlipByDayfromtoFarmerIdAsync(from,to,id));
        }

        [Route("milkcoupon/{from}/{to}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkCouponByDayfromtoAsync(int from, int to)
        {
            return Ok(await _dashboardMilkCouponService.GetDashboardMilkCouponByDayfromtoAsync(from, to));
        }

        [Route("milkcoupon/{from}/{to}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(int from, int to, int id)
        {
            return Ok(await _dashboardMilkCouponService.GetDashboardMilkCouponByDayfromtoFarmerIdAsync(from, to, id));
        }

        [Route("orderFood/{from}/{to}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardOrderFoodByDayfromtoAsync(int from, int to)
        {
            return Ok(await _dashboardOrderFoodService.GetDashboardOrderFoodByDayfromtoAsync(from, to));
        }

        [Route("orderFood/{from}/{to}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardOrderFoodByDayfromtoFarmerIdAsync(int from, int to, int id)
        {
            return Ok(await _dashboardOrderFoodService.GetDashboardOrderFoodByDayfromtoFarmerIdAsync(from, to, id));
        }

        [Route("using/{from}/{to}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardUsingByDayfromtoAsync(int from, int to)
        {
            return Ok(await _dashboardUsingService.GetDashboardUsingByDayfromtoAsync(from, to));
        }

        [Route("using/{from}/{to}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDashboardUsingByDayfromtoFarmerIdAsync(int from, int to, int id)
        {
            return Ok(await _dashboardUsingService.GetDashboardUsingByDayfromtoFarmerIdAsync(from, to, id));
        }
    }
}