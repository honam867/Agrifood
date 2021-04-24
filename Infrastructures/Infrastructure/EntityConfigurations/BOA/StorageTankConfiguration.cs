using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class StorageTankConfiguration : EntityConfigurationBase<StorageTank, int>
    {
        public override void OnConfigure(EntityTypeBuilder<StorageTank> builder)
        {
            builder.HasOne(p => p.MilkCollectionStation).WithMany().HasForeignKey(p => p.MilkCollectionStationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
