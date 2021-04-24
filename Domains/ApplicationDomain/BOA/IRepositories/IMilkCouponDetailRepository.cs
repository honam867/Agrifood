using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IMilkCouponDetailRepository : IGenericRepository<MilkCouponDetail, int>
    {
        IQueryable GetMilkCouponDetails();
        IQueryable GetMilkCouponDetailById(int id);
        //Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetMilkcouponDetailByMilkcouponId(int id, int userId);
    }
}
