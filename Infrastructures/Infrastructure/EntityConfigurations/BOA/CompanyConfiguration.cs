using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class CompanyConfiguration : EntityConfigurationBase<Company, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Company> builder)
        {
        }
    }
}
