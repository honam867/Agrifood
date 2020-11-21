using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using System.Linq;

namespace Infrastructure.Repositories.Identity
{
    public class PermissionMembershipRepository : GenericRepository<PermissionMembership, int>, IPermissionMembershipRepository
    {
        public PermissionMembershipRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable GetAllMemberByPermissionGroupId(int id)
        {
            return this.dbSet.Where(p => p.PermissionGroupId == id);
        }
        public IQueryable GetAllGroupByUserId(int userId)
        {
            return this.dbSet.Where(p => p.UserId == userId).Select(p => p.PermissionGroupId);
        }
    }
}
