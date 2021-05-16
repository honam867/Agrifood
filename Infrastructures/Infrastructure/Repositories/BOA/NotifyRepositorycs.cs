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
    public class NotifyRepository : GenericRepository<Notify, int>, INotifyRepository
    {
        public NotifyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetNotifys()
        {
            return this.dbSet;
        }

        public IQueryable GetNotifyById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetNotifyByFarmerId(int id)
        {
            return dbSet.Where(a => a.FarmerId == id);
        }

        public IQueryable GetNotifyByEmployeeId(int id)
        {
            return dbSet.Where(a => a.EmployeeId == id);
        }
    }
}
