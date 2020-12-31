using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class WardConfiguration : EntityConfigurationBase<Ward, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Ward> builder)
        {
            builder.HasOne(p => p.District).WithMany().HasForeignKey(p => p.DistrictId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
