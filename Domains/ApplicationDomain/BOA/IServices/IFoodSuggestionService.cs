using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FoodSuggestions;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IFoodSuggestionService
    {
        Task<IEnumerable<FoodSuggestionModel>> GetFoodSuggestionsAsync();
        Task<FoodSuggestionModel> GetFoodSuggestionByIdAsync(int id);
        Task<int> CreateFoodSuggestionAsync(FoodSuggestionModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteFoodSuggestionAsync(int id);
        Task<bool> UpdateFoodSuggestionAsync(int id, FoodSuggestionModelRq model, UserIdentity<int> issuer);
   /*     Task<bool> CheckCodeExistsAsync(string code);*/
    }
}
