using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Breeds;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IBreedService
    {
        Task<IEnumerable<BreedModel>> GetBreedsAsync();
        Task<BreedModel> GetBreedByIdAsync(int id);
        Task<int> CreateBreedAsync(BreedModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteBreedAsync(int id);
        Task<bool> UpdateBreedAsync(int id, BreedModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
