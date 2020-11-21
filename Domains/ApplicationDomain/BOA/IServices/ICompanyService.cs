using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Companys;
using AspNetCore.Common.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyModel>> GetCompanyAsync();
        Task<CompanyModel> GetCompany();
        string GetCodeAsync();
        Task<CompanyModel> GetCompanyByIdAsync(int id);
        Task<int> CreateCompanyAsync(CompanyModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteCompanyAsync(int id);
        Task<bool> UpdateCompanyAsync(int id, CompanyModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCompanyExistsAsync();
        Task<bool> UploadLogoAsync(IFormFile file, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
