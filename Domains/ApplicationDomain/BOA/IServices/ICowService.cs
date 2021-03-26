using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Cows;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface ICowService
    {
        Task<IEnumerable<CowModel>> GetCowsAsync();
        Task<CowModel> GetCowByIdAsync(int id);
        Task<IEnumerable<CowModel>> GetCowByByreId(int byreId);
        Task<int> CreateCowAsync(CowModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteCowAsync(int id);
        Task<bool> UpdateCowAsync(int id, CowModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
