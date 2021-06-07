using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IFoodSuggestionRepository : IGenericRepository<FoodSuggestion, int>
    {
        IQueryable GetFoodSuggestions();
        IQueryable GetFoodSuggestionById(int id);
        IQueryable GetFoodSuggestionByFarmerId(int id);
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetFoodSuggestionByProvinceId(int id);
    }
}
