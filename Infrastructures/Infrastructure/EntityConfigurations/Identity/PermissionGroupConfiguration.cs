using ApplicationDomain.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.Identity
{
    public class PermissionGroupConfiguration : EntityConfigurationBase<PermissionGroup, int>
    {
        public override void OnConfigure(EntityTypeBuilder<PermissionGroup> builder)
        {
            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTimeOffset.Now);
            builder.Property(p => p.UpdatedDate).HasDefaultValue(DateTimeOffset.Now);
        }

    }
}
