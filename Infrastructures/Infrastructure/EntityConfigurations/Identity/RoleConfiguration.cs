using ApplicationDomain.Identity.Entities;
using AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Identity
{
    public class RoleConfiguration : EntityConfigurationBase<Role>
    {
        public override void OnConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.RowVersion).IsConcurrencyToken();

            builder.Property(p => p.CreatedByUserName).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();

            builder.Property(p => p.UpdatedByUserName).IsRequired();
            builder.Property(p => p.UpdatedDate).IsRequired();

        }
    }
}
