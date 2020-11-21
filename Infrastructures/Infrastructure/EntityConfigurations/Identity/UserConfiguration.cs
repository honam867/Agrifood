using ApplicationDomain.Core;
using ApplicationDomain.Identity.Entities;
using AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Identity
{
    public class UserConfiguration : EntityConfigurationBase<User>
    {
        public override void OnConfigure(EntityTypeBuilder<User> builder)
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
