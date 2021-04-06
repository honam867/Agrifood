using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class ImportHistoryConfiguration : EntityConfigurationBase<ImportHistory, int>
    {
        public override void OnConfigure(EntityTypeBuilder<ImportHistory> builder)
        {
            builder.HasOne(p => p.WareHouse).WithMany().HasForeignKey(p => p.WareHouseId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
