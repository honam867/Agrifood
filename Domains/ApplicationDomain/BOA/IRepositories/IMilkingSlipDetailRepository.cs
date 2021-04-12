using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IMilkingSlipDetailRepository : IGenericRepository<MilkingSlipDetail, int>
    {
        IQueryable GetMilkingSlipDetails();
        IQueryable GetMilkingSlipDetailById(int id);
        IQueryable GetMilkingSlipDetailByMilkingSlipId(int id);
        //Task<bool> CheckCodeExistsAsync(string code);

    }
}
