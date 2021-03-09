using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Identity
{
    public class FarmerPermissionRepository : GenericRepository<FarmerPermission, int>, IFarmerPermissionRepository
    {
        public FarmerPermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable GetFarmerPmsByPermissionGroupId(int id)
        {
            return this.dbSet.Where(p => p.PermissionGroupId == id);
        }

        public IQueryable GetFarmerPmsByListPermissionGroupId(List<int> groupIds)
        {
            return this.dbSet.Where(p => groupIds.Contains(p.PermissionGroupId));
        }

        //public async Task<List<int>> GetGroupsCanApprove()
        //{
        //    return await this.dbSet.Where(r => r.CanApprove).Select(r => r.PermissionGroupId).ToListAsync();
        //}
    }
}
