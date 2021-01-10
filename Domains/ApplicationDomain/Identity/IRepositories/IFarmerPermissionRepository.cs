using ApplicationDomain.Identity.Entities;
using AspNetCore.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IFarmerPermissionRepository : IGenericRepository<FarmerPermission, int>
    {
        IQueryable GetFarmerPmsByPermissionGroupId(int id);
        IQueryable GetFarmerPmsByListPermissionGroupId(List<int> groupIds);
        //Task<List<int>> GetGroupsCanApprove();
    }
}
