using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.Models.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IServices
{
    public interface IPermissionGroupService
    {
        Task<IEnumerable<PermissionGroup>> GetPermissionGroups();
        Task<int> CreatePermissionGroup(PermissionGroupDetailRq permissionGroupDetailRq);
        Task<PermissionGroupDetailModel> GetPermissionGroupById(int id);
        Task<bool> DeletePermissionGroup(int id);
        Task<bool> UpdatePermissionGroup(int id, PermissionGroupDetailRq permissionGroupDetailRq);
    }
}
