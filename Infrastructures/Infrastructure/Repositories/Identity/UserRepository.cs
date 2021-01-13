
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using ApplicationDomain.Identity.Models;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDomain.Helper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Repositories.Identity
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private ApplicationDbContext _dbContext;
        private IRoleRepository _roleRepository;
        

        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager ,ApplicationDbContext dbContext, IRoleRepository roleRepository) : base(dbContext)
        {
     
            _dbContext = dbContext;
            _userManager = userManager;
            _roleRepository = roleRepository;
        }
        public IQueryable GetUsers()
        {
            var users = (from user in _userManager.Users
                         let query = (from userRoles in _dbContext.UserRoles
                                      where userRoles.UserId.Equals(user.Id)
                                      join r in _dbContext.Roles on userRoles.RoleId equals r.Id
                                      select r.Name)
                         select new UserModel
                         {
                             Id = user.Id,
                             AvatarURL = user.AvatarURL,
                             Email = user.Email,
                             PhoneNumber = user.PhoneNumber,
                             Status = user.Status,
                             UserName = user.UserName,
                             CreatedByUserName = user.CreatedByUserName,
                             CreatedDate = user.CreatedDate,
                             UpdatedByUserName = user.UpdatedByUserName,
                             UpdatedDate = user.UpdatedDate,
                             Roles = query.ToList()
                         });
            return users;
        }

        public string GetNetResetCodeByResetCode(string code)
        {
            var entity = dbSet.Where(r => r.ResetCode == code).FirstOrDefault();
            return entity != null ? entity.NetResetCode : string.Empty;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var entity = await this.dbSet
                .Where(r => r.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
            return entity ;
        }

        //public IQueryable<User> GetManagerUsers()
        //{
        //    var managers = from uRole in _dbContext.UserRoles
        //        from user in _userManager.Users
        //        from role in _dbContext.Roles
        //        where role.Name == ROLE_CONSTANT.MANAGER && uRole.RoleId == role.Id && uRole.UserId == user.Id
        //        select new User()
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            UserName = user.UserName
        //        };
        //    return managers;
        //} 
        //public IQueryable<User> GetDirectorUsers()
        //{
        //    var directors = from uRole in _dbContext.UserRoles
        //        from user in _userManager.Users
        //        from role in _dbContext.Roles
        //        where role.Name == ROLE_CONSTANT.DIRECTOR && uRole.RoleId == role.Id && uRole.UserId == user.Id
        //        select new User()
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            UserName = user.UserName
        //        };
        //    return directors;
        //}
        public IQueryable<User> GetEmployeeUsers()
        {
            var employee = from uRole in _dbContext.UserRoles
                from user in _userManager.Users
                from role in _dbContext.Roles
                where role.Name == ROLE_CONSTANT.EMPLOYEE && uRole.RoleId == role.Id && uRole.UserId == user.Id
                select new User()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName
                };
            return employee;
        }

        /* public async Task<string>  GetRoleByUser(int userId)
         {

             var query = from uRole in _dbContext.UserRoles
                         where uRole.UserId == userId
                         select uRole.RoleId;
             return query.ToString();
         }*/

        /*public async Task<List<string>> GetRolesByUserId(int userId)
        {
           

            *//*var userRoles = from identityUserRole in _dbContext.UserRoles
                            join identityRole in _dbContext.Roles
                    on identityUserRole.RoleId equals identityRole.Id
                            where identityUserRole.UserId == userId
                            select identityRole.Name;*//*
            Console.WriteLine(userRoles.ToList());
            return userRoles.ToList();
        }*/

        public IQueryable<UpdateUserRoleModelRq> GetRoleByUser(int userId)
        {
            var query = from uRole in _dbContext.UserRoles
                        where uRole.UserId == userId
                        select new UpdateUserRoleModelRq
                        {
                            RoleName = uRole.UserId.ToString()
                        };
            
            return query;

        }
    }
}
