using ApplicationDomain.BOA.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
