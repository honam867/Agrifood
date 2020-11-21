using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class DepartmentConfiguration : EntityConfigurationBase<Department, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(p => p.Branch).WithMany().HasForeignKey(p => p.BranchId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
