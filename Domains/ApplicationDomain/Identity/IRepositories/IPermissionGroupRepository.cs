using ApplicationDomain.Identity.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IPermissionGroupRepository : IGenericRepository<PermissionGroup, int>
    {
    }
}