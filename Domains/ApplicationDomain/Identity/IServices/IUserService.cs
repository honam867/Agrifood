
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.Models;
using AspNetCore.Common.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IServices
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetListUsers();
        Task<int> CreateUserAsync(CreatedUserRq model, UserIdentity<int> issuer = null);
        Task<int> UpdateUserAsync(int id, UpdatedUserRq model, UserIdentity<int> issuer);
        Task<bool> DeleteUserAsync(int id);
        Task<UserModel> GetUserById(int id);
        Task<bool> AddRoleToUserAsync(UpdateUserRoleModelRq model);
        Task<bool> RemoveRoleToUserAsync(UpdateUserRoleModelRq model);
        Task<IList<string>> GetRoleByUser(int userId);
        Task<bool> AddRolesToUser(AddRolesToUserModelRq model);
        Task<int> CreateUserRegistrationAsync(CreatedUserRq model);
        //Task<IEnumerable<User>> GetManagerUsersAsync();
        //Task<IEnumerable<User>> GetDirectorUsersAsync(); 
        Task<IEnumerable<User>> GetEmployeeUsersAsync();
        Task<IList<string>> GetRoleByUser(User user);
        Task<bool> CheckEmailAsync(string email);
    }
}
