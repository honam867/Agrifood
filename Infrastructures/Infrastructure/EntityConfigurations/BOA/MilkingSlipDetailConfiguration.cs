using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class MilkingSlipDetailConfiguration : EntityConfigurationBase<MilkingSlipDetail, int>
    {
        public override void OnConfigure(EntityTypeBuilder<MilkingSlipDetail> builder)
        {
            builder.HasOne(p => p.MilkingSlip).WithMany().HasForeignKey(p => p.MilkingSlipId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Cow).WithMany().HasForeignKey(p => p.CowId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
