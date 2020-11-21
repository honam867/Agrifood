using ApplicationDomain.Identity.Entities;
using AspNetCore.Common.Identity;
using AspNetCore.Domain;
using System;

namespace ApplicationDomain.Core.Entities
{
    public abstract class EntityBase<TKeyType> : IVersionedEntity<TKeyType>, IEntity<TKeyType>
    {

        public TKeyType Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }     // use to query/join
        public string CreatedByUserName { get; set; } // Use to display

        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; } // use to query/join
        public string UpdatedByUserName { get; set; } // Use to display

        public byte[] RowVersion { get; set; }


        public EntityBase<TKeyType> CreateBy(UserIdentity<int> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            CreatedByUserId = issuer.Id;
            CreatedByUserName = issuer.UserName;
            CreatedDate = now;

            return this;
        }

        public EntityBase<TKeyType> UpdateBy(UserIdentity<int> issuer)
        {
            var now = DateTimeOffset.UtcNow;

            UpdatedByUserId = issuer.Id;
            UpdatedByUserName = issuer.UserName;
            UpdatedDate = now;

            return this;
        }
    }
}
