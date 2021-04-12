using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSQL;
using System.Data;
using AspNetCore.DataBinding.AutoMapper;
using ApplicationDomain.BOA.Models.Cows;

namespace Infrastructure.Repositories.BOA
{
    public class CowRepository : GenericRepository<Cow, int>, ICowRepository
    {
        public CowRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetCows()
        {
            return this.dbSet;
        }

        public IQueryable GetCowById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetCowByByreId(int byreId)
        {

            var list = this.dbSet.Include(r => r.Byre).Where(t => t.ByreId == byreId);
            return list;

        }

        public IQueryable GetCowsByFarmerId(int farmerId)
        {
            var list = this.dbSet.Include(o => o.Byre).Where(q => q.Byre.FarmerId == farmerId);
            return list;
        }
        public IQueryable GetCowNotExitsByMilkingSlipId(int id)
        {
            //IQueryable result = dbSet.Except(from c in dbSet
            //                                 join mkd in context.Set<MilkingSlipDetail>() on c.Id equals mkd.CowId
            //                                 where mkd.MilkingSlipId == id
            //                                 select c);
            var cowId = from c in dbSet
                        join mkd in context.Set<MilkingSlipDetail>() on c.Id equals mkd.CowId
                        where mkd.MilkingSlipId == id
                        select c.Id;
            var result = from c in dbSet
                         where !cowId.Contains(c.Id) && c.Gender == "Cái"
                         select c;
            return result;
        }
    }
}
