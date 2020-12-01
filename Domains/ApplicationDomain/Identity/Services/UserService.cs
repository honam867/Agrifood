
using ApplicationDomain.Core.Entities;
using ApplicationDomain.Core.IRepositories;
using ApplicationDomain.Helper;
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using ApplicationDomain.Identity.IServices;
using ApplicationDomain.Identity.Models;
using AspNetCore.AutoGenerate;
using AspNetCore.Common.Exceptions;
using AspNetCore.Common.Identity;
using AspNetCore.Common.Messages;
using AspNetCore.EmailSender;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailSender _emailSender;
        private readonly IEmailRepository _emailTemplateRepository;
        private readonly UserManager<User> _userManagement;
        private readonly RoleManager<Role> _roleManager;
        public UserService(
            IMapper mapper,
            IUnitOfWork uow,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            UserManager<User> userManagement,
            IEmailSender emailSender,
            RoleManager<Role> roleManager,
            IEmailRepository emailTemplateRepository
            ) : base(mapper, uow)
        {
            _userRepository = userRepository;
            _userManagement = userManagement;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _emailTemplateRepository = emailTemplateRepository;
        }

        public IEnumerable<UserModel> GetListUsers()
        {
            try
            {
                return _userRepository.GetUsers().Cast<UserModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<string>> GetRoleByUser(int userId)
        {
            try
            {
                var identity = await _userManagement.FindByIdAsync(userId.ToString());
                var user = await _userManagement.GetRolesAsync(identity);
                return user;
            }
            catch (Exception e )
            {
                Console.WriteLine(e );
                throw;
            }
        }

        public async Task<IList<string>> GetRoleByUser(User user)
        {
            try
            {
                var roles = await _userManagement.GetRolesAsync(user);
                return roles;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _userManagement.FindByIdAsync(id.ToString());
            var result = _mapper.Map<UserModel>(user);
            return result;
        }

        public async Task<int> CreateUserAsync(CreatedUserRq model, UserIdentity<int> issuer = null)
        {
            try
            {
                model.Status = true;
                var user = _mapper.Map<User>(model);
                if (issuer != null)
                {
                    user.CreateBy(issuer).UpdateBy(issuer);
                }
                //string password = AutoGenerate.AutoGeneratePassword(8, true, true);
                string password = "Agrifoodsystem1";
                var identityResult = await _userManagement.CreateAsync(user, password);

                if (!identityResult.Succeeded)
                {
                    throw CreateException(identityResult.Errors);
                }

                await _userManagement.AddToRoleAsync(user, ROLE_CONSTANT.EMPLOYEE);
                EmailTemplate emailTemplate = await _emailTemplateRepository.GetEmailTemplateByNameAsync("NewUserEmail");
                emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", model.Email);
                emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", model.UserName);
                emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#password", password);
                try
                {
                    await _emailSender.SendEmailAsync(model.Email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
                }
                catch (Exception e)
                {
                    throw e;
                }
                return user.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> FarmerSignUpAsync(CreatedFarmerRq model, UserIdentity<int> issuer = null)
        {
            try
            {
                model.Status = true;
                var farmer = _mapper.Map<User>(model);
                if (issuer != null)
                {
                    farmer.CreateBy(issuer).UpdateBy(issuer);
                }
                var identityResult = await _userManagement.CreateAsync(farmer, model.Password);

                if (!identityResult.Succeeded)
                {
                    throw CreateException(identityResult.Errors);
                }

                await _userManagement.AddToRoleAsync(farmer, ROLE_CONSTANT.FARMER);
                return farmer.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CheckPhoneNumberAsync(string phone)
        {
            try
            {

                var user = await _userRepository.GetUserByPhoneNumber(phone);
                if (user != null)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Exception CreateException(IEnumerable<IdentityError> errors)
        {
            var exception = new UserDefinedException();
            exception.UserDefinedMessage = new ExceptionMessage();
            exception.UserDefinedMessage.Details = new List<ExceptionMessage>();

            foreach (var error in errors)
            {
                exception.UserDefinedMessage.Details.Add(new ExceptionMessage
                {
                    Message = error.Description
                });
            }
            exception.UserDefinedMessage.Message = exception.UserDefinedMessage.Details.First().Message;

            return exception;
        }

        public async Task<int> UpdateUserAsync(int id, UpdatedUserRq model, UserIdentity<int> issuer)
        {
            var user = await _userManagement.FindByIdAsync(id.ToString());
            _mapper.Map(model, user);

            user.UpdateBy(issuer);
            await _userManagement.UpdateAsync(user);
            await _uow.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userManagement.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return false;
            }
            _userRepository.Delete(user);

            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddRoleToUserAsync(UpdateUserRoleModelRq model)
        {
            try
            {
                var user = await _userManagement.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                {
                    return false;
                }
                var rs = await _userManagement.AddToRoleAsync(user, model.RoleName);
                if (rs.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> RemoveRoleToUserAsync(UpdateUserRoleModelRq model)
        {
            try
            {
                var user = await _userManagement.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                {
                    return false;
                }
                var roles = await _userManagement.GetRolesAsync(user);
                if (roles.Count > 1)
                {
                    var rs = await _userManagement.RemoveFromRoleAsync(user, model.RoleName);
                    if (rs.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            try
            {
                var user = await _userManagement.FindByEmailAsync(email);
                return user != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AddRolesToUser(AddRolesToUserModelRq model)
        {
            try
            {
                var user = await _userManagement.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                {
                    return false;
                }
                foreach (var item in model.Roles)
                {
                    var rs = await _userManagement.AddToRoleAsync(user, item.Name);
                    if (!rs.Succeeded)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

   

        //public async Task<IEnumerable<User>> GetManagerUsersAsync()
        //{
        //    try
        //    {
        //        return await _userRepository.GetManagerUsers().ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //} 

        //public async Task<IEnumerable<User>> GetDirectorUsersAsync()
        //{
        //    try
        //    {
        //        return await _userRepository.GetDirectorUsers().ToListAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //} 
        public async Task<IEnumerable<User>> GetEmployeeUsersAsync()
        {
            try
            {
                return await _userRepository.GetEmployeeUsers().ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> CreateUserRegistrationAsync([FromBody]CreatedUserRq model)
        {
            try
            {
                var entity = new User()
                {
                    UserName = model.UserName,
                    PasswordHash = model.Password,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                string password = model.Password;

                var identityResult = await _userManagement.CreateAsync(entity, password);

                if (!identityResult.Succeeded)
                {
                    throw CreateException(identityResult.Errors);
                }
                var rs = await _userManagement.AddToRoleAsync(entity, model.Role);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
