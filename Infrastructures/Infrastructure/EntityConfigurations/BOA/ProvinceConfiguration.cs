using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class ProvinceConfiguration : EntityConfigurationBase<Province, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Province> builder)
        {

        }
    }
}
