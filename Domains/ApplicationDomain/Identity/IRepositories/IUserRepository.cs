

using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.Models;
using AspNetCore.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        IQueryable GetUsers();
        /*IQueryable<User> GetRoleByUsers();*/
        //IQueryable<User> GetDirectorUsers();
        IQueryable<User> GetEmployeeUsers();
        /* Task<User> GetRoleByUser(int userId);*/
        IQueryable<UpdateUserRoleModelRq> GetRoleByUser(int userId);
        string GetNetResetCodeByResetCode(string code);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
       /* Task<List<string>> GetRolesByUserId(int userId);*/
    }
}
