using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class FoodConfiguration : EntityConfigurationBase<Food, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Food> builder)
        {
            builder.HasOne(p => p.Province).WithMany().HasForeignKey(p => p.Provinceid).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
