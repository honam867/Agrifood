using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class FeedHistoryConfiguration : EntityConfigurationBase<FeedHistory, int>
    {
        public override void OnConfigure(EntityTypeBuilder<FeedHistory> builder)
        {
            builder.HasOne(p => p.Cow).WithMany().HasForeignKey(p => p.CowId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
