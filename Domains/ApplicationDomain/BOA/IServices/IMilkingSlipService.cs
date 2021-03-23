using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IMilkingSlipService
    {
        Task<IEnumerable<MilkingSlipModel>> GetMilkingSlipAsync();
        Task<MilkingSlipModel> GetMilkingSlipByIdAsync(int id);
        Task<int> CreateMilkingSlipAsync(MilkingSlipModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteMilkingSlipAsync(int id);
        Task<bool> UpdateMilkingSlipAsync(int id, MilkingSlipModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<string> AutoGenerateCodeAsync(string code = "");
    }
}
