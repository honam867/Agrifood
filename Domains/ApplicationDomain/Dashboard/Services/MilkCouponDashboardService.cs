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
    public class MilkCouponDashboardService : IMilkCouponDashboardService
    {
        private readonly IMilkCouponDashboardRepository _milkCouponDashboardRepository;

        public MilkCouponDashboardService(IMilkCouponDashboardRepository milkCouponDashboardRepository) 
        {
            _milkCouponDashboardRepository = milkCouponDashboardRepository;

        }

        public async Task<IEnumerable<MilkCouponDashboardModel>> GetMilkCouponDashboardAsync(int month, int year, int farmerId)
        {
            try
            {
                return await _milkCouponDashboardRepository.GetMilkCouponDashboardAsync(month,year,farmerId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
