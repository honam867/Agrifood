using ApplicationDomain.Identity.Entities;
using AspNetCore.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IPermissionMembershipRepository : IGenericRepository<PermissionMembership, int>
    {
        IQueryable GetAllMemberByPermissionGroupId(int id);
        IQueryable GetAllGroupByUserId(int userId);
    }
}
