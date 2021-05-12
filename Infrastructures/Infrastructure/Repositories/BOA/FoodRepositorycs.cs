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
    public class FoodRepository : GenericRepository<Food, int>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetFoods()
        {
            return this.dbSet;
        }

        public IQueryable GetFoodById(int id)
        {
            var result = dbSet.Where(r => r.Id == id);
            return result;
        }

        public IQueryable GetFoodByProvince(int id)
        {
            var result = from f in dbSet
                         join fm in context.Set<Farmer>() on f.ProvinceId equals fm.ProvinceId
                         where fm.UserId == id
                         select f;
            return result;
        }
    }
}
