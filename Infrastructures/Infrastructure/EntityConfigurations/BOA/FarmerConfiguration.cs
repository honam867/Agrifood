using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class FarmerConfiguration : EntityConfigurationBase<Farmer, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Farmer> builder)
        {
            builder.HasOne(p => p.User).WithOne().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            builder.HasOne(p => p.MilkCollectionStation).WithMany().HasForeignKey(p => p.MilkCollectionStationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
