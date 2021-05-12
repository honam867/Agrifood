using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class FeedHistoryDetailConfiguration : EntityConfigurationBase<FeedHistoryDetail, int>
    {
        public override void OnConfigure(EntityTypeBuilder<FeedHistoryDetail> builder)
        {
            builder.HasOne(p => p.FeedHistory).WithMany().HasForeignKey(p => p.FeedHistoryId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Food).WithMany().HasForeignKey(p => p.FoodId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
