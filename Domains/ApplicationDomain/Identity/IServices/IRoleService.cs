using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.Models;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IServices
{
    public interface IRoleService
    {
        Task<int> CreateRoleAsync(RoleCreatedModelRq model, UserIdentity<int> issuer);
        IEnumerable<RoleListModel> GetListRoles();
        RoleListModel GetRoleById(int id);
        Task<bool> UpdateRoleAsync(int id, RoleCreatedModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteRoleAsync(int id);
        Task<IEnumerable<RoleListModel>> GetRoleNotExistsInUserRoleId(int userId);
        Task<bool> CreateDefaultEntityRolesAsync(UserIdentity<int> issuer);
        Task<string> GetRoleQuotationEmployee();
        Task<string> GetRoleQuotationManager();
        Task<string> GetRoleQuotationDirector();
        Task<string> GetRoleQuotationCommerce();
        Task<string> GetRoleQuotationService();
    }
}
