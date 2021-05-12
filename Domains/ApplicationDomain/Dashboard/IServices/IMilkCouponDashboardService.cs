using ApplicationDomain.Dashboard.Models.MilkCoupons;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IServices
{
    public interface IMilkCouponDashboardService
    {
        Task<IEnumerable<MilkCouponDashboardModel>> GetMilkCouponDashboardAsync(int month, int year, int farmerId);
    }
}
