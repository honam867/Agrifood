using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class MilkCollectionStationConfiguraion : EntityConfigurationBase<MilkCollectionStation, int>
    {
        public override void OnConfigure(EntityTypeBuilder<MilkCollectionStation> builder)
        {
            builder.HasOne(p => p.Ward).WithMany().HasForeignKey(p => p.WardId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
