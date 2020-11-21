using ApplicationDomain.Identity.Models;
using AspNetCore.Common.Identity;
using AspNetCore.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Entities
{
    public class Role : IdentityRole<int>, IVersionedEntity<int>
    {
        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }     // use to query/join
        public string CreatedByUserName { get; set; } // Use to display
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; }     // use to query/join
        public string UpdatedByUserName { get; set; } // Use to display
        public byte[] RowVersion { get; set; }

        public Role()
        {
            var now = DateTimeOffset.UtcNow;
            CreatedDate = now;
            UpdatedDate = now;
            CreatedByUserName = "";
            UpdatedByUserName = "";
        }

        public Role CreateBy(UserIdentity<int> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            CreatedByUserId = issuer.Id;
            CreatedByUserName = issuer.UserName;

            return this;
        }

        public Role UpdateBy(UserIdentity<int> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            UpdatedByUserId = issuer.Id;
            UpdatedByUserName = issuer.UserName;
            UpdatedDate = now;

            return this;
        }

        public class RoleModelMapper : Profile
        {
            public RoleModelMapper()
            {
                CreateMap<Role, Role>();
            }
        }
    }
}
