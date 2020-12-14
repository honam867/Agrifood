using ApplicationDomain.BOA.Models.Farmers;
using AspNetCore.Common.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IFarmerService
    {
        Task<IEnumerable<FarmerModel>> GetFarmerListAsync();
        Task<FarmerModel> GetFarmerByIdAsync(int id);
        Task<int> CreateFarmerAsync(FarmerModelRq model, UserIdentity<int> issuer);
        Task<string> AutoGenerateCodeAsync(string code = "");
        Task<bool> UpdateFarmerAsync(int id, FarmerModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteFarmerAsync(int id);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
