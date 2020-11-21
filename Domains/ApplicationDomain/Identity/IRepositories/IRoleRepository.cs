using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.Models;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IRoleRepository: IGenericRepository<Role, int>
    {
        IQueryable GetListRoles();
        IQueryable GetRoleById(int id);
        IQueryable GetRoleNotExistsInUserRoleId(int userId);
        int GetRoleEmployee();
        int GetRoleManager();
        int GetRoleDirector();
        string GetNameRoleEmployee();
        string GetNameRoleManager();
        string GetNameRoleDirector();
        Task<bool> CheckNameExists(string name);
        Task<string> GetRoleQuotationEmployeeAsync();
        Task<string> GetRoleQuotationManagerAsync();
        Task<string> GetRoleQuotationDirectorAsync();
        Task<string> GetRoleQuotationServiceAsync();
        Task<string> GetRoleQuotationCommerceAsync();
        int GetRoleQuotationEmployee();
        int GetRoleQuotationManager();
        int GetRoleQuotationDirector();
        int GetRoleQuotationCommerce();
        int GetRoleQuotationService();
        Task<string> GetRoleContractEmployeeAsync();
        Task<string> GetRoleContractManagerAsync();
        Task<string> GetRoleContractDirectorAsync();
        Task<string> GetRoleContractServiceAsync();
        Task<string> GetRoleContractCommerceAsync();
        int GetRoleContractEmployeeIdAsync();
        int GetRoleContractDirectorIdAsync();
        int GetRoleContractManagerIdAsync();

    }
}
