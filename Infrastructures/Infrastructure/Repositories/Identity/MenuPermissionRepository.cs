using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.Identity
{
    public class MenuPermissionRepository : GenericRepository<MenuPermission, int>, IMenuPermissionRepository
    {
        public MenuPermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable GetMenuPermissionByPermissionGroupId(int id)
        {
            return this.dbSet.Where(p => p.PermissionGroupId == id);
        }
        public IQueryable GetMenuPermissionsByPermissionGroupId(List<int> groupIds)
        {
            return this.dbSet.Where(p => groupIds.Contains(p.PermissionGroupId));
        }
    }
}