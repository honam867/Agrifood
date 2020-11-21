using System;
using ApplicationDomain.Core.IServices;
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models;
using ApplicationDomain.Identity.Models.Users;
using AspNetCore.Common.Identity;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ApplicationDomain.Identity.IRepositories;
using AspNetCore.AutoGenerate;

namespace ApplicationDomain.Identity.Services
{
    public class AuthService : ServiceBase, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        public AuthService(
            IMapper mapper,
            IUnitOfWork uow,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IEmailService emailService,
            IUserRepository userRepository
            ) : base(mapper, uow)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<SignInModel> SignInAsync(string userName, string password, bool lockoutOnFailure)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return new SignInModel
                {
                    Succeeded = false
                };
            }

            var signInResult = new SignInModel(await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure));
            if (!signInResult.Succeeded)
            {
                return signInResult;
            }

            signInResult.Roles = await _userManager.GetRolesAsync(user);
            signInResult.UserIdentity = new UserIdentity<int>
            {
                Id = user.Id,
                UserName = user.UserName,
            };
            signInResult.AvatarURL = user.AvatarURL ?? "";
            return signInResult;
        }
        public async Task<bool> CheckEmailAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {

                    user.ResetCode = AutoGenerate.GetRandomDigit(6);
                    user.NetResetCode = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.UpdateAsync(user);
                }
                return user != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<string> CheckPhoneNumberAsync(string phone)
        {
            try
            {

                var user = await _userRepository.GetUserByPhoneNumber(phone);
                if (user != null)
                {
                    user.ResetCode = AutoGenerate.GetRandomDigit(6);
                    user.NetResetCode = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    return "0";
                }
                return user.ResetCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public async Task<bool> ChangePasswordAsync(UserChangePasswordRq model, UserIdentity<int> issuer)
        {
            var user = await _userManager.FindByIdAsync(issuer.Id.ToString());
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return false;
            }

            user.UpdateBy(issuer);
            await _uow.SaveChangesAsync();

            await _emailService.SendEmailChangePasswordAsync(user.Email, user.UserName);

            return true;
        }
        public async Task<bool> ChangePasswordMobileAsync(ResetPasswordRq model)
        {
            try
            {
                string netCode = _userRepository.GetNetResetCodeByResetCode(model.Code);

                if (netCode.Equals(string.Empty))
                {
                    return false;
                }

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return false;
                }

                var result = await _userManager.ResetPasswordAsync(user, netCode, model.Password);

                if (!result.Succeeded)
                {
                    return false;
                }

                await _uow.SaveChangesAsync();
                await _emailService.SendEmailResetPasswordAsync(user.Email, user.UserName);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }
        public async Task<bool> ChangePasswordMobileByPhoneAsync(ResetPasswordRq model)
        {
            try
            {
                string netCode = _userRepository.GetNetResetCodeByResetCode(model.Code);

                if (netCode.Equals(string.Empty))
                {
                    return false;
                }

                var user = await _userRepository.GetUserByPhoneNumber(model.PhoneNumber);
                if (user == null)
                {
                    return false;
                }

                var result = await _userManager.ResetPasswordAsync(user, netCode, model.Password);

                if (!result.Succeeded)
                {
                    return false;
                }

                await _uow.SaveChangesAsync();
                await _emailService.SendEmailResetPasswordAsync(user.Email, user.UserName);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<bool> TLTQuotationAsync(TLTQuotationRq model, UserIdentity<int> issuer)
        {
            var user = await _userManager.FindByIdAsync(issuer.Id.ToString());
            if (user == null)
            {
                return false;
            }
            user.UpdateBy(issuer);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckExistUserPasswordAsync(int id, UserCheckPasswordRq model)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var passwordOK = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordOK)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ForgotPasswordAsync(UserForgotPasswordRq model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return false;
            }

            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            //update user 
            await _emailService.SendEmailForgotPasswordAsync(user.Email, user.UserName, code);
            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordRq model)
        {
    
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return false;
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                if (!result.Succeeded)
                {
                    return false;
                }

                await _uow.SaveChangesAsync();
                await _emailService.SendEmailResetPasswordAsync(user.Email, user.UserName);
                return true;
            }
            catch (Exception e)
            {

                throw e; 
            }
        }

    }
}
