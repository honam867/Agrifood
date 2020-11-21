using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.EntityFramework
{
    public abstract class EntityConfigurationBase<TEntity> : IEntityConfiguration where TEntity : class
    {
        public void Configure(ModelBuilder builder)
        {
            var typeBuilder = builder.Entity<TEntity>();

            OnConfigure(typeBuilder);
        }
        public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);
    }
}
