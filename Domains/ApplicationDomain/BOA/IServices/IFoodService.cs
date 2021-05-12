using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Foods;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodModel>> GetFoodsAsync();
        Task<FoodModel> GetFoodByIdAsync(int id);
        Task<int> CreateFoodAsync(FoodModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteFoodAsync(int id);
        Task<bool> UpdateFoodAsync(int id, FoodModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<FoodModel>> GetFoodByProvinceIdAsync(int id);
    }
}
