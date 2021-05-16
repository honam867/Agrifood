﻿using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.BOA
{
    public class NotifyConfiguration : EntityConfigurationBase<Notify, int>
    {
        public override void OnConfigure(EntityTypeBuilder<Notify> builder)
        {
            builder.HasOne(p => p.Farmer).WithMany().HasForeignKey(p => p.FarmerId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Employee).WithMany().HasForeignKey(p => p.EmployeeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
