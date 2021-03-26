using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IMilkCouponRepository : IGenericRepository<MilkCoupon, int>
    {
        IQueryable GetMilkCoupons();
        IQueryable GetMilkCouponById(int id);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
