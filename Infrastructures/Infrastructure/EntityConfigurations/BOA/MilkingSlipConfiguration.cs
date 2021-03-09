using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class MilkingSlipConfiguration : EntityConfigurationBase<MilkingSlip, int>
    {
        public override void OnConfigure(EntityTypeBuilder<MilkingSlip> builder)
        {
            builder.HasOne(p => p.Farmer).WithMany().HasForeignKey(p => p.FarmerId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
