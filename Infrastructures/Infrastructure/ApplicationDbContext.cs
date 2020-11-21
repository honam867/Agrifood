using ApplicationDomain.Identity.Entities;
using AspNetCore.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public object GetUnitOfWorkContext()
        {
            return this;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var configLoader = new ConfigurationLoader<ApplicationDbContext>(builder);
            configLoader.Load();
        }
    }
}
