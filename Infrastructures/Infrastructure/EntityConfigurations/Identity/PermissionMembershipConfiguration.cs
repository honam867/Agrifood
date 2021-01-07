using ApplicationDomain.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.Identity
{
    public class PermissionMembershipConfiguration : EntityConfigurationBase<PermissionMembership, int>
    {
        public override void OnConfigure(EntityTypeBuilder<PermissionMembership> builder)
        {
            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTimeOffset.Now);
            builder.Property(p => p.UpdatedDate).HasDefaultValue(DateTimeOffset.Now);

            builder.HasOne(p => p.PermissionGroup).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            builder.HasOne(p => p.User).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }

    }
}
