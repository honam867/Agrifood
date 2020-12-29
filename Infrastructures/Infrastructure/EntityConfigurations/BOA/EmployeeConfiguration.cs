using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class EmployeeConfiguration : EntityConfigurationBase<Employee, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
