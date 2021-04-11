using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BOA
{
    public class MilkingSlipDetailRepository : GenericRepository<MilkingSlipDetail, int>, IMilkingSlipDetailRepository
    {
        private ICowRepository _cowRepository;
        public MilkingSlipDetailRepository(ApplicationDbContext dbContext, ICowRepository cowRepository) : base(dbContext)
        {
            _cowRepository = cowRepository;
        }

        //public async Task<bool> CheckCodeExistsAsync(string code)
        //{
        //    return await this.dbSet.AnyAsync(r => r.Code == code);
        //}

        public IQueryable GetMilkingSlipDetails()
        {
            return this.dbSet;
        }

        public IQueryable GetMilkingSlipDetailById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetMilkingSlipDetailByMilkingSlipId(int id)
        {
            IQueryable rs = dbSet.Where(a => a.MilkingSlipId == id);
            return rs;
        }

        
    }
}
