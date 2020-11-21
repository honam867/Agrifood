using ApplicationDomain.BOA.Models;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictModel>> GetDistrictsAsync();
        Task<DistrictModel> GetDistrictByIdAsync(int id);
        Task<IEnumerable<DistrictModel>> GetDistricByPrivinceIdAsync(int id);
        Task<int> CreateDistrictAsync(DistrictModelRq model, UserIdentity<int> issuer);
        Task<bool> UpdateDistrictAsync(int id, DistrictModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteDistrictAsync(int id);
        Task<bool> ImportDistrictFromAPIAsync(UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<string> AutoGenerateCodeAsync(string code = "");
    }
}
