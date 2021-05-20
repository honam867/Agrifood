using ApplicationDomain.BOA.Models.MilkCoupons;
using ApplicationDomain.Dashboard.IRepositories;
using ApplicationDomain.Dashboard.IServices;
using ApplicationDomain.Dashboard.Models.MilkCoupons;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.Services
{
    public class DashboardMilkCouponService : IDashboardMilkCouponService
    {
        private readonly IDashboardMilkCouponRepository _dashboardMilkCouponRepository;

        public DashboardMilkCouponService(IDashboardMilkCouponRepository dashboardMilkCouponRepository) 
        {
            _dashboardMilkCouponRepository = dashboardMilkCouponRepository;

        }

        public async Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(int from, int to)
        {
            try
            {
                return await _dashboardMilkCouponRepository.GetDashboardMilkCouponByDayfromtoAsync(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(int from, int to, int farmerId)
        {
            try
            {
                return await _dashboardMilkCouponRepository.GetDashboardMilkCouponByDayfromtoFarmerIdAsync(from,to,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
