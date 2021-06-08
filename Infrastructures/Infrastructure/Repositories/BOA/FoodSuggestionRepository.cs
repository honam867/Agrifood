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
    public class FoodSuggestionRepository : GenericRepository<FoodSuggestion, int>, IFoodSuggestionRepository
    {
        public FoodSuggestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetFoodSuggestions()
        {
            return this.dbSet;
        }

        public IQueryable GetFoodSuggestionById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetFoodSuggestionByFarmerId(int id)
        {
            return dbSet.Where(a => a.CreatedByUserId == id);
        }

        public IQueryable GetFoodSuggestionByProvinceId(int id)
        {
            var result = from fg in dbSet
                         join f in context.Set<Food>() on fg.FoodId equals f.Id
                         join fm in context.Set<Farmer>() on f.ProvinceId equals fm.ProvinceId
                         where fm.UserId == id
                         select fg;
            return result;
        }
    }
}
