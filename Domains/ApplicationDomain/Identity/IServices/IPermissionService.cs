using ApplicationDomain.Identity.Models.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IServices
{
    public interface IPermissionService
    {
        Task<GrantedPermission> GetGrantedPermission(int userId, IList<string> roles = null);
    
    }
}
