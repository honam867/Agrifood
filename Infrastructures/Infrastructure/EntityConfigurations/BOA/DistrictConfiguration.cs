using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class DistrictConfiguration : EntityConfigurationBase<District, int>
    {
        public override void OnConfigure(EntityTypeBuilder<District> builder)
        {
            builder.HasOne(p => p.Province).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
