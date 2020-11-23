using ApplicationDomain.Helper;
using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using ApplicationDomain.Identity.Models;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Identity
{
    public class RoleRepository : GenericRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable GetListRoles()
        {            
            return dbSet;
        }

        public IQueryable GetRoleById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetRoleNotExistsInUserRoleId(int userId)
        {
            IQueryable rs = this.dbSet
                .Where(r => !this.context.Set<IdentityUserRole<int>>()
                        .Where(p => p.UserId == userId)
                        .Select(p => p.RoleId)
                        .Contains(r.Id));
            return rs;
        }

        public async Task<bool> CheckNameExists(string name)
        {
            bool rs = await this.dbSet
                .Where(r => r.Name == name).AnyAsync();
            return rs;
        }

        public async Task<string> GetRoleQuotationEmployeeAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == ROLE_CONSTANT.EMPLOYEE));
            return rs == null ? string.Empty : rs.Name;
        }

        public int GetRoleQuotationEmployee()
        {
            int rs = this.dbSet
                .Where(r => r.Name == ROLE_CONSTANT.EMPLOYEE)
                .Select(r => r.Id)
                .FirstOrDefault();
            return rs;
        }

        //public int GetRoleQuotationManager()
        //{
        //    int rs = this.dbSet
        //        .Where(r => r.Name == ROLE_CONSTANT.MANAGER)
        //        .Select(r => r.Id)
        //        .FirstOrDefault();
        //    return rs;
        //}

        public int GetRoleQuotationCommerce()
        {
            int rs = this.dbSet
                .Where(r => r.Name == "QuotationCommerce")
                .Select(r => r.Id)
                .FirstOrDefault();
            return rs;
        }


        public int GetRoleQuotationService()
        {
            int rs = this.dbSet
                .Where(r => r.Name == "QuotationService")
                .Select(r => r.Id)
                .FirstOrDefault();
            return rs;
        }

        //public int GetRoleQuotationDirector()
        //{
        //    int rs = this.dbSet
        //        .Where(r => r.Name == ROLE_CONSTANT.DIRECTOR)
        //        .Select(r => r.Id)
        //        .FirstOrDefault();
        //    return rs;
        //}

        //public async Task<string> GetRoleQuotationManagerAsync()
        //{
        //    var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == ROLE_CONSTANT.MANAGER));
        //    return rs == null ? string.Empty : rs.Name;
        //}

        //public async Task<string> GetRoleQuotationDirectorAsync()
        //{
        //    var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == ROLE_CONSTANT.DIRECTOR));
        //    return rs == null ? string.Empty : rs.Name;
        //}

        public async Task<string> GetRoleQuotationServiceAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "QuotationService"));
            return rs == null ? string.Empty : rs.Name;
        }

        public async Task<string> GetRoleQuotationCommerceAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "QuotationCommerce"));
            return rs == null ? string.Empty : rs.Name;
        }

        public async Task<string> GetRoleContractEmployeeAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "ContractEmployee"));
            return rs == null ? string.Empty : rs.Name;
        }

        public async Task<string> GetRoleContractManagerAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "ContractManager"));
            return rs == null ? string.Empty : rs.Name;
        }

        public async Task<string> GetRoleContractDirectorAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "ContractDirector"));
            return rs == null ? string.Empty : rs.Name;
        }

        public async Task<string> GetRoleContractServiceAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "ContractService"));
            return rs == null ? string.Empty : rs.Name;
        }

        public async Task<string> GetRoleContractCommerceAsync()
        {
            var rs = (await this.dbSet.FirstOrDefaultAsync(r => r.Name == "ContractCommerce"));
            return rs == null ? string.Empty : rs.Name;
        }

        public int GetRoleContractEmployeeIdAsync()
        {
            int rs = this.dbSet
                 .Where(r => r.Name == "ContractEmployee")
                 .Select(r => r.Id)
                 .FirstOrDefault();
            return rs;
        }

        public int GetRoleContractDirectorIdAsync()
        {
            int rs = this.dbSet
                .Where(r => r.Name == "ContractDirector")
                .Select(r => r.Id)
                .FirstOrDefault();
            return rs;
        }

        public int GetRoleContractManagerIdAsync()
        {
            int rs = this.dbSet
                .Where(r => r.Name == "ContractManager")
                .Select(r => r.Id)
                .FirstOrDefault();
            return rs;
        }

        

        public int GetRoleEmployee()
        {
            int rs = this.dbSet
                 .Where(r => r.Name == ROLE_CONSTANT.EMPLOYEE)
                 .Select(r => r.Id)
                 .FirstOrDefault();
            return rs;
        }

        //public int GetRoleManager()
        //{
        //    int rs = this.dbSet
        //         .Where(r => r.Name == ROLE_CONSTANT.MANAGER)
        //         .Select(r => r.Id)
        //         .FirstOrDefault();
        //    return rs;
        //}

        //public int GetRoleDirector()
        //{
        //    int rs = this.dbSet
        //         .Where(r => r.Name == ROLE_CONSTANT.DIRECTOR)
        //         .Select(r => r.Id)
        //         .FirstOrDefault();
        //    return rs;
        //}

        public string GetNameRoleEmployee()
        {
            var rs = (this.dbSet.FirstOrDefault(r => r.Name == ROLE_CONSTANT.EMPLOYEE));
            return rs == null ? string.Empty : rs.Name;
        }

        //public string GetNameRoleManager()
        //{
        //    var rs = (this.dbSet.FirstOrDefault(r => r.Name == ROLE_CONSTANT.MANAGER));
        //    return rs == null ? string.Empty : rs.Name;
        //}

        //public string GetNameRoleDirector()
        //{
        //    var rs = (this.dbSet.FirstOrDefault(r => r.Name == ROLE_CONSTANT.DIRECTOR));
        //    return rs == null ? string.Empty : rs.Name;
        //}
    }
}
