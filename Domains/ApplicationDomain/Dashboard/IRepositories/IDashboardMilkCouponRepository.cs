using ApplicationDomain.Dashboard.Models.MilkCoupons;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IDashboardMilkCouponRepository
    {
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(int from, int to);
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(int from, int to, int farmerId);
    }
}
