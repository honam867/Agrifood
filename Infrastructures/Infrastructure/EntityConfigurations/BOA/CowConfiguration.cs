using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class CowConfiguration : EntityConfigurationBase<Cow, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Cow> builder)
        {
            builder.HasOne(p => p.FoodSuggestion).WithMany().HasForeignKey(p => p.FoodSuggestionId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
