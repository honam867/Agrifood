using ApplicationDomain.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.Identity
{
    public class FarmerPermissionConfiguration : EntityConfigurationBase<FarmerPermission, int>
    {
        public override void OnConfigure(EntityTypeBuilder<FarmerPermission> builder)
        {
            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTimeOffset.Now);
            builder.Property(p => p.UpdatedDate).HasDefaultValue(DateTimeOffset.Now);
            builder.HasOne(p => p.PermissionGroup).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

    }
}
