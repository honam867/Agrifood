using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Entities
{
    public class PermissionMembership : EntityBase<int>
    {
        public int PermissionGroupId { set; get; }
        public PermissionGroup PermissionGroup { set; get; }
        public int UserId { set; get; }
        public User User { set; get; }

        public PermissionMembership(int permissionGroupId, int userId)
        {
            PermissionGroupId = permissionGroupId;
            UserId = userId;
        }
        public PermissionMembership()
        {

        }
    }
}
