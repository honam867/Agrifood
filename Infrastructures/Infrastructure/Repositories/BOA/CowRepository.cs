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
using Infrastructures;

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
        public IQueryable GetCowNotExitsByMilkingSlipId(int milkingSlipId, int userId)
        {
            //IQueryable result = dbSet.Except(from c in dbSet
            //                                 join mkd in context.Set<MilkingSlipDetail>() on c.Id equals mkd.CowId
            //                                 where mkd.MilkingSlipId == id
            //                                 select c);

            var cowId = from c in dbSet.Include(o => o.Byre).Where(q => q.CreatedByUserId == userId)
                        join mkd in context.Set<MilkingSlipDetail>() on c.Id equals mkd.CowId
                        where mkd.MilkingSlipId == milkingSlipId
                        select c.Id;
            var result = from c in dbSet.Include(o => o.Byre).Where(q => q.CreatedByUserId == userId)
                         where !cowId.Contains(c.Id) && c.Gender == "Cái"
                         select c;
            return result;
        }

        public IQueryable GetCowByGender(int gd, int userId)
        {
            string gender = "";
            if(gd == 0)
            {
                gender = "Cái";
            } else
            {
                gender = "Đực";
            }
            return dbSet.Where(a => a.Gender == gender).Include(a => a.Byre).Where(q => q.CreatedByUserId == userId);
        }
    }
}
