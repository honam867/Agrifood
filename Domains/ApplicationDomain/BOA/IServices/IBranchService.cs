using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Branchs;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchModel>> GetBranchsAsync();
        Task<BranchModel> GetBranchByIdAsync(int id);
        Task<int> CreateBranchAsync(BranchModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteBranchAsync(int id);
        Task<bool> UpdateBranchAsync(int id, BranchModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
