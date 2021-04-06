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
    public class WarehouseRepository : GenericRepository<Warehouse, int>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<bool> CheckCodeExistsAsync(string code)
        //{
        //    return await this.dbSet.AnyAsync(r => r.Code == code);
        //}

        public IQueryable GetWarehouses()
        {
            return this.dbSet;
        }

        public IQueryable GetWarehouseById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

    }
}
