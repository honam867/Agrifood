using ApplicationDomain.Identity.Models.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IServices
{
    public interface IPermissionService
    {
        Task<GrantedFarmerPermission> GetGrantedFarmerPermission(int userId, IList<string> roles = null);
    }
}
