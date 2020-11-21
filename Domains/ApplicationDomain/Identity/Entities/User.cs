using ApplicationDomain.Core;
using AspNetCore.Common.Identity;
using AspNetCore.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Entities
{
    public class User : IdentityUser<int>, IVersionedEntity<int>
    {
        public string AvatarURL { set; get; }
        //public int PermissionId { set; get; }
        //public Permission Permission { set; get; }
        public byte[] RowVersion { get; set; }
        public bool Status { set; get; }
        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { set; get; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public string UpdatedByUserName { set; get; }
        public string NetResetCode { set; get; }
        public string ResetCode { set; get; }

        public User()
        {
            var now = DateTimeOffset.UtcNow;
            CreatedDate = now;
            UpdatedDate = now;
            CreatedByUserName = "";
            UpdatedByUserName = "";
        }

        public User CreateBy(UserIdentity<int> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            CreatedByUserId = issuer.Id;
            CreatedDate = now;

            return this;
        }

        public User UpdateBy(UserIdentity<int> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            UpdatedByUserId = issuer.Id;
            UpdatedDate = now;

            return this;
        }

        public class UserCreateModelMapper : Profile
        {
            public UserCreateModelMapper()
            {
                CreateMap<User, User>();
            }
        }
    }
}