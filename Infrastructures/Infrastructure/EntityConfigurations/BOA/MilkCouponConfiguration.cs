using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class MilkCouponConfiguraion : EntityConfigurationBase<MilkCoupon, int>
    {
        public override void OnConfigure(EntityTypeBuilder<MilkCoupon> builder)
        {
            builder.HasOne(p => p.MilkCollectionStation).WithMany().HasForeignKey(p => p.MilkCollectionStationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Employee).WithMany().HasForeignKey(p => p.EmployeeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Farmer).WithMany().HasForeignKey(p => p.FarmerId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
