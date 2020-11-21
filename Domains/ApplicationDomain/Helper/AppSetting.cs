using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApplicationDomain.Helper
{
    public static class AppSetting
    {
        public static string GetValue(string key)
        {
            string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", optional: true)
                                                    .AddJsonFile($"appsettings.{envName}.json", optional: true)
                                                    .Build();

            return configuration.GetValue<string>(key);
        }
    }
}
