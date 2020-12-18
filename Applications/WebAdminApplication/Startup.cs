using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApplicationDomain.Identity.Entities;
using AspNetCore.Common.Azure;
using AspNetCore.Common.ConnectionString;
using AspNetCore.Common.Dropbox;
using AspNetCore.Common.FileRequirement;
using AspNetCore.EmailSender;
using AspNetCore.IoC.Autofact;
using AspNetCore.Mvc;
using AspNetCore.Mvc.JwtBearer;
using AspNetCore.UnitOfWork.EntityFramework;
using AutoMapper;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebAdminApplication
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var EFConnectionString = Configuration.GetConnectionString("DefaultConnection");
            var jwtSecurityKey = Configuration.GetValue<string>("Security:Jwt:SecurityKey");
            var tokenTimeOutMinutes = Configuration.GetValue<long>("Security:Jwt:TokenTimeOutMinutes");



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] {}
                    }
                });
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    // Filter out 3rd party controllers
                    var assemblyName = ((ControllerActionDescriptor)apiDesc.ActionDescriptor).ControllerTypeInfo.Assembly.GetName().Name;
                    var currentAssemblyName = GetType().Assembly.GetName().Name;
                    return currentAssemblyName == assemblyName;
                });

            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(EFConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure();
                });
            });

            services
                .AddMvcApi()
                .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<ApplicationDomain.AssemplyMarker>().RegisterValidatorsFromAssemblyContaining<Startup>());
            //services.AddCors();
            //services.AddAutoMapper(typeof(Domain.AssemplyMarker));

            // Add UoW 
            services.AddUnitOfWork<ApplicationDbContext>();
            // Add Identity
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); // protection provider responsible for generating an email confirmation token or a password reset token
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(tokenTimeOutMinutes);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddAutoMapper(typeof(ApplicationDomain.AssemplyMarker));

            // Add Jwt Bearer
            // IMPORTANCE: AddJwtBearerAuthentication should be added after services.AddIdentity, to replaced Authentication config in Identity
            services.AddJwtBearerAuthentication(options =>
            {
                options.SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey));
                options.TokenTimeOutMinutes = tokenTimeOutMinutes;
            });

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();

            services.Configure<AzureSettings>(Configuration.GetSection("AzureSettings"));
            services.AddSingleton<IAzure, Azure>();

            services.Configure<ConnectionSettings>(Configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<IConnection, Connection>();

            services.Configure<FileRequirementSettings>(Configuration.GetSection("FileRequirementSettings"));
            services.AddSingleton<IFileRequirement, FileRequirement>();
            services.Configure<DropboxSettings>(Configuration.GetSection("DropboxSettings"));
            services.AddSingleton<IDropbox, AspNetCore.Common.Dropbox.Dropbox>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.AddDevExpressControls();
            services.ConfigureReportingServices(configurator =>
            {
                configurator.ConfigureReportDesigner(designerConfigurator =>
                {
                    designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
                });
            });
            // ALL SERVICE REGISTERS SHOULD BE PLACED BEFORE THIS LINE
            // Register our custom service provider
            var autofactServiceProvider = services.BuildAutofactServiceProvider(options =>
            {
                // Register services,...
                options.AddAsImplementedInterfaces(typeof(ApplicationDomain.AssemplyMarker));
                // Register repositories
                options.AddAsImplementedInterfaces(typeof(Infrastructure.AssemplyMarker));
            });
            return autofactServiceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var reportDirectory = Path.Combine(env.ContentRootPath, "Reports");
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new CustomReportStorageWebExtension(reportDirectory));
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;


            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors("AllowAll");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "index.html");

                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    //c.RoutePrefix = string.Empty;
                });
            }
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });


        }
    }
}