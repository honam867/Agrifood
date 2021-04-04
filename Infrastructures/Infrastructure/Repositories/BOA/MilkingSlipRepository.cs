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
    public class MilkingSlipRepository : GenericRepository<MilkingSlip, int>, IMilkingSlipRepository
    {
        public MilkingSlipRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetMilkingSlips()
        {
            return this.dbSet;
        }

        public IQueryable GetMilkingSlipById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetMilkingSlipByDate(int date, int month, int year, int session)
        {
            string sessionString = "";
            if(session == 0)
            {
                sessionString = "Sáng";
            }
            else
            {
                sessionString = "Chiều";
            }
            var data = dbSet.Where(a => a.CreatedDate.Day == date)
                .Where(a => a.CreatedDate.Month == month)
                .Where(a => a.CreatedDate.Year == year)
                .Where(a => a.Session == sessionString);
            return data;
        }
    }
}
