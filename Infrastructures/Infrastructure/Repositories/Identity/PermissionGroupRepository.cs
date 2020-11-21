using ApplicationDomain.Identity.Entities;
using ApplicationDomain.Identity.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Identity
{
    public class PermissionGroupRepository : GenericRepository<PermissionGroup, int>, IPermissionGroupRepository
    {
        public PermissionGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}