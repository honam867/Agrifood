using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkCouponDetails;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IMilkCouponDetailService
    {
        Task<IEnumerable<MilkCouponDetailModel>> GetMilkCouponDetailAsync();
        Task<MilkCouponDetailModel> GetMilkCouponDetailByIdAsync(int id);
        Task<int> CreateMilkCouponDetailAsync(MilkCouponDetailModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteMilkCouponDetailAsync(int id);
        Task<bool> UpdateMilkCouponDetailAsync(int id, MilkCouponDetailModelRq model, UserIdentity<int> issuer);
        //Task<bool> CheckCodeExistsAsync(string code);
        Task<MilkCouponDetailModel> GetMilkcouponDetailByMilkcouponIdAsync(int id);
    }
}
