using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class BranchConfiguration : EntityConfigurationBase<Branch, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasOne(p => p.Company).WithMany().HasForeignKey(p => p.CompanyId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
