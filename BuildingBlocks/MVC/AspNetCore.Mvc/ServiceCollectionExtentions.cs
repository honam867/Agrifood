using AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc
{
    public static class ServiceCollectionExtentions
    {
        public static IMvcBuilder AddMvc(this IServiceCollection services)
        {
            var mvcBuilder = services.AddMvc(options => {
                options.Filters.Add(new ExceptionFilter());
            });

            mvcBuilder.AddJsonOptions(x => {
                x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
            });
            return mvcBuilder;
        }
        public static IMvcCoreBuilder AddMvcApi(this IServiceCollection services)
        {
            var mvcBuilder = services.AddMvcCore(options => {
                options.Filters.Add(new ExceptionFilter());
            });

            mvcBuilder.AddApiExplorer();
            mvcBuilder.AddJsonFormatters();
            mvcBuilder.AddDataAnnotations();
            mvcBuilder.AddAuthorization();
            mvcBuilder.AddCors(options => {
                options.AddPolicy(CorsPolicies.AllowAny, builder => {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            mvcBuilder.AddJsonOptions(x => {
                x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
            });

            return mvcBuilder;
        }
    }
}
