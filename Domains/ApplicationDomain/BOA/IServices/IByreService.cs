using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Byres;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IByreService
    {
        Task<IEnumerable<ByreModel>> GetByresAsync();
        Task<ByreModel> GetByreByIdAsync(int id);
        Task<int> CreateByreAsync(ByreModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteByreAsync(int id);
        Task<bool> UpdateByreAsync(int id, ByreModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
