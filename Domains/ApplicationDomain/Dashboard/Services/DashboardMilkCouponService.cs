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
        private readonly IDashboardMilkCouponRepository _milkCouponDashboardRepository;

        public DashboardMilkCouponService(IDashboardMilkCouponRepository milkCouponDashboardRepository) 
        {
            _milkCouponDashboardRepository = milkCouponDashboardRepository;

        }

        public async Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(DateTime dayFrom, DateTime dayTo)
        {
            try
            {
                return await _milkCouponDashboardRepository.GetDashboardMilkCouponByDayfromtoAsync(dayFrom, dayTo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId)
        {
            try
            {
                return await _milkCouponDashboardRepository.GetDashboardMilkCouponByDayfromtoFarmerIdAsync(dayFrom,dayTo,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
