using ApplicationDomain.Dashboard.Models.MilkCoupons;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Dashboard.IRepositories
{
    public interface IMilkCouponDashboardRepository
    { 
        Task<IEnumerable<MilkCouponDashboardModel>> GetMilkCouponDashboardAsync(int month, int year, int farmerId);
    }
}
