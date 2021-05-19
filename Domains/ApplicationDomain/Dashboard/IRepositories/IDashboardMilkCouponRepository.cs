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
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoFarmerIdAsync(DateTime dayFrom, DateTime dayTo, int farmerId);
        Task<IEnumerable<DashboardMilkCouponModel>> GetDashboardMilkCouponByDayfromtoAsync(DateTime dayFrom, DateTime dayTo);
    }
}
