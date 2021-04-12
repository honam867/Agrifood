using ApplicationDomain.Identity.Models;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IServices
{
    public interface IAuthService
    {
        Task<SignInModel> SignInAsync(string userName, string password, bool lockoutOnFailure);

        Task<bool> ChangePasswordAsync(UserChangePasswordRq model, UserIdentity<int> issuer);
        Task<bool> ForgotPasswordAsync(UserForgotPasswordRq model);
        Task<bool> ResetPasswordAsync(ResetPasswordRq model);
        Task<bool> CheckExistUserPasswordAsync(int id, UserCheckPasswordRq model);
        Task<bool> CheckEmailAsync(string email);
        Task<bool> ChangePasswordMobileAsync(ResetPasswordRq model);
        Task<string> CheckPhoneNumberAsync(string phone);
        Task<bool> ChangePasswordMobileByPhoneAsync(ResetPasswordRq model);
    }
}
