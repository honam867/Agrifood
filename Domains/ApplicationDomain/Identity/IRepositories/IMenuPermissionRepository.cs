using ApplicationDomain.Identity.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IMenuPermissionRepository : IGenericRepository<MenuPermission, int>
    {
        IQueryable GetMenuPermissionByPermissionGroupId(int id);
        IQueryable GetMenuPermissionsByPermissionGroupId(List<int> groupIds);
    }
}