using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.UnitOfWork.EntityFramework
{
    public static class ServiceCollectionExtentions
    {
        public static void AddUnitOfWork<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
        }
    }
}
