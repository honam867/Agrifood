using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Infrastructure.DbMigration
{
    /// <summary>
    /// When you run dotnet ef migrations
    /// It will looking for IDesignTimeDbContextFactory to create an instance of your DbContext
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// This this project, I expected that args[0] is our connection string
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            string connectionString = (args.Length > 0 ? args[0] : null) ?? GetConnectionStringFromAppSetting();
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection String is required");
            }


            builder.UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure();
                sqlServerOptions.MigrationsAssembly(
                    typeof(DesignTimeDbContextFactory).GetTypeInfo().Assembly.GetName().Name);
            });
            return new ApplicationDbContext(builder.Options);
        }

        private string GetConnectionStringFromAppSetting()
        {
            Console.WriteLine("Read connection string from appsettings.json");

            string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", optional: true)
                                                    .AddJsonFile($"appsettings.{envName}.json", optional: true)
                                                    .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
