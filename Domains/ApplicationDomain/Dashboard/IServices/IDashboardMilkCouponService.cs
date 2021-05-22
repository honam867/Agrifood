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
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(int from, int to);
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(int from, int to, int farmerId);
    }
}
