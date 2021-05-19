using ApplicationDomain.Dashboard.Models.MilkCoupons;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IDashboardMilkCouponService
    {
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId);
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(DateTime dayFrom, DateTime dayTo);
    }
}
