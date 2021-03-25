using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class MilkCouponDetailConfiguraion : EntityConfigurationBase<MilkCouponDetail, int>
    {
        public override void OnConfigure(EntityTypeBuilder<MilkCouponDetail> builder)
        {
            builder.HasOne(p => p.MilkCoupon).WithMany().HasForeignKey(p => p.MilkCouponId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
