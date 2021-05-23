using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkCoupons;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IMilkCouponService
    {
        Task<IEnumerable<MilkCouponModel>> GetMilkCouponAsync();
        Task<MilkCouponModel> GetMilkCouponByIdAsync(int id);
        Task<int> CreateMilkCouponAsync(MilkCouponModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteMilkCouponAsync(int id);
        Task<bool> UpdateMilkCouponAsync(int id, MilkCouponModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<string> AutoGenerateCodeAsync(string code = "");
        Task<bool> UpdateStatusAsync(int id, UserIdentity<int> issuer);
    }
}
