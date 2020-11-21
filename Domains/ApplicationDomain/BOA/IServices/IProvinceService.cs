using ApplicationDomain.BOA.Models;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceModel>> GetListProvincesAsync();
        Task<ProvinceModel> GetProvinceByIdAsync(int id);
        Task<int> CreateProvinceAsync(ProvinceModelRq model, UserIdentity<int> issuer);
        Task<bool> UpdateProvinceAsync(int id, ProvinceModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteProvinceAsync(int id);
        Task<bool> ImportProvinceFromAPIAsync(UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<string> AutoGenerateCodeAsync(string code = "");
    }
}
