using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkingSlipDetails;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IMilkingSlipDetailService
    {
        Task<IEnumerable<MilkingSlipDetailModel>> GetMilkingSlipDetailAsync();
        Task<MilkingSlipDetailModel> GetMilkingSlipDetailByIdAsync(int id);
        Task<int> CreateMilkingSlipDetailAsync(MilkingSlipDetailModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteMilkingSlipDetailAsync(int id);
        Task<bool> UpdateMilkingSlipDetailAsync(int id, MilkingSlipDetailModelRq model, UserIdentity<int> issuer);
        //Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<MilkingSlipDetailModel>> GetMilkingSlipDetailByMilkingSlipIdAsync(int id);
        
    }
}
