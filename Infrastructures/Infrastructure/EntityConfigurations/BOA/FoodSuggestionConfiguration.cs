using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class FoodSuggestionConfiguration : EntityConfigurationBase<FoodSuggestion, int>
    {
        public override void OnConfigure(EntityTypeBuilder<FoodSuggestion> builder)
        {
            builder.HasOne(p => p.Food).WithMany().HasForeignKey(p => p.FoodId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
