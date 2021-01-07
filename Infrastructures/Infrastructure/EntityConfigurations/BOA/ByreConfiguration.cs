using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class ByreConfiguration : EntityConfigurationBase<Byre, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Byre> builder)
        {
            builder.HasOne(p => p.Breed).WithMany().HasForeignKey(p => p.BreedId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
