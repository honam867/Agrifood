﻿using ApplicationDomain.BOA.Entities;
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
            builder.HasOne(p => p.District).WithMany().HasForeignKey(p => p.DistrictId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.TypeOfMilk).WithMany().HasForeignKey(p => p.TypeOfMilkId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
