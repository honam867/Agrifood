using ApplicationDomain.BOA.Entities;
using ApplicationDomain.Core.Entities;
using ApplicationDomain.Helper;
using ApplicationDomain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    class Program
    {
        public static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting to seed data");
            _serviceProvider = ConfigureService(new ServiceCollection(), args);
            using (var dbContext = _serviceProvider.GetService<ApplicationDbContext>())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    SeedDataAsync(dbContext).Wait();
                    transaction.Commit();
                    Console.WriteLine("Commit all seed");
                }
            }
            Console.WriteLine("Seed data successfull");
        }

        public static IServiceProvider ConfigureService(IServiceCollection services, string[] args)
        {
            var dbContextFactory = new DesignTimeDbContextFactory();

            services.AddLogging();
            services.AddScoped<ApplicationDbContext>(p => dbContextFactory.CreateDbContext(args));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            return services.BuildServiceProvider();
        }
        private static async Task SeedDataAsync(ApplicationDbContext dbContext)
        {
            IdentityResult systemAdminResult = await SeedSystemAdminAsync(dbContext);
            if (systemAdminResult.Succeeded)
            {
                await SeedRoleAsync(dbContext);
            }
            var userManagement = _serviceProvider.GetService<UserManager<User>>();
            var systemAdmin = userManagement.FindByNameAsync("sysadmin").Result;
            await userManagement.AddToRoleAsync(systemAdmin, ROLE_CONSTANT.SYSADMIN);
            await SeedEmailTemplate(dbContext);
            await SeedDistrictAsync(dbContext,
               await SeedProvinceAsync(dbContext));
                        await SeedCompanyAsync(dbContext);
      
          



        }

    
        private static async Task SeedRoleAsync(ApplicationDbContext dbContext)
        {
            var roleManagers = _serviceProvider.GetService<RoleManager<Role>>();
            var userManager = _serviceProvider.GetService<UserManager<User>>();
            var user = userManager.FindByNameAsync("sysadmin").Result;
            var roleSystem = new Role

            {
                Name = ROLE_CONSTANT.SYSADMIN,
                CreatedByUserId = user.Id,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = user.UserName,
                UpdatedByUserId = user.Id,
                UpdatedDate = DateTimeOffset.UtcNow,
                UpdatedByUserName = user.UserName
            };
            await roleManagers.CreateAsync(roleSystem);
            await dbContext.SaveChangesAsync();
            var roleEmployee = new Role
            {
                Name = ROLE_CONSTANT.EMPLOYEE,
                CreatedByUserId = user.Id,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = user.UserName,
                UpdatedByUserId = user.Id,
                UpdatedDate = DateTimeOffset.UtcNow,
                UpdatedByUserName = user.UserName
            };
            await roleManagers.CreateAsync(roleEmployee);
            await dbContext.SaveChangesAsync();
            var roleFarmer = new Role
            {
                Name = ROLE_CONSTANT.FARMER,
                CreatedByUserId = user.Id,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = user.UserName,
                UpdatedByUserId = user.Id,
                UpdatedDate = DateTimeOffset.UtcNow,
                UpdatedByUserName = user.UserName
            };
            await roleManagers.CreateAsync(roleFarmer);
            await dbContext.SaveChangesAsync();
            //var roleCustomer = new Role
            //{
            //    Name = ROLE_CONSTANT.CUSTOMER,
            //    CreatedByUserId = user.Id,
            //    CreatedDate = DateTimeOffset.UtcNow,
            //    CreatedByUserName = user.UserName,
            //    UpdatedByUserId = user.Id,
            //    UpdatedDate = DateTimeOffset.UtcNow,
            //    UpdatedByUserName = user.UserName
            //};
            //await roleManagers.CreateAsync(roleCustomer);
            await dbContext.SaveChangesAsync();

            var roleAdmin = new Role
            {
                Name = ROLE_CONSTANT.ADMIN,
                CreatedByUserId = user.Id,
                CreatedDate = DateTimeOffset.UtcNow,
                CreatedByUserName = user.UserName,
                UpdatedByUserId = user.Id,
                UpdatedDate = DateTimeOffset.UtcNow,
                UpdatedByUserName = user.UserName
            };
            await roleManagers.CreateAsync(roleAdmin);
            await dbContext.SaveChangesAsync();
        }


        private static async Task<IdentityResult> SeedSystemAdminAsync(ApplicationDbContext dbContext)
        {
            try
            {
                if (!await dbContext.Set<User>().AnyAsync())
                {
                    Console.WriteLine("Start to seed sysadmin");

                    var userManagement = _serviceProvider.GetService<UserManager<User>>();
                    var user = new User
                    {
                        UserName = "sysadmin",
                        Email = "nam.t171846@gmail.com",
                        PhoneNumber = "0868336756",
                        CreatedByUserId = 1,
                        CreatedDate = DateTimeOffset.UtcNow,
                        CreatedByUserName = "sysadmin",
                        UpdatedByUserId = 1,
                        UpdatedDate = DateTimeOffset.UtcNow,
                        UpdatedByUserName = "sysadmin",
                        Status = true,

                    };
                    IdentityResult rs = await userManagement.CreateAsync(user, "Password@1");
                 
                    Console.WriteLine("Finished seed usersysadmin");
                    return rs;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw ex;
            }

        }


        private static async Task<int> SeedCompanyAsync(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Start to seed Company");
            var userManagement = _serviceProvider.GetService<UserManager<User>>();
            var system = userManagement.FindByNameAsync("sysadmin").Result;
            var model = new Company
            {
                Code = "VNT",
                Email = "VNT@gmail.com",
                Address = "Quận 12",
                Fax = "123456789",
                ForeignName = "Viet Nhat Tan",
                LogoURL = "http://www.vietnhattan.com.vn/wp-content/uploads/2016/12/cropped-VNT_LOGO-192x192.png",
                Name = "CTY TNHH CƠ KHÍ CHÍNH XÁC VIỆT NHẬT TÂN",
                PhoneNumber = "0936915227",
                ShortName = "VNT",
                TaxCode = "123456789",
                WebsiteURL = "http://www.vietnhattan.com.vn/",
                CreatedByUserId = system.Id,
                CreatedByUserName = system.UserName,
                UpdatedByUserId = system.Id,
                UpdatedByUserName = system.UserName,
            };
            await dbContext.AddAsync(model);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Finished seed Company");
            return model.Id;
        }


        //private static async Task<int> SeedBranchAsync(ApplicationDbContext dbContext, int companyid)
        //{
        //    Console.WriteLine("Start to seed Branch");
        //    var userManagement = _serviceProvider.GetService<UserManager<User>>();
        //    var system = userManagement.FindByNameAsync("sysadmin").Result;
        //    var model = new Branch
        //    {
        //        Code = "HCM",
        //        Email = "VNThcm@gmail.com",
        //        Address = "Binh tan",
        //        Fax = "123456789",
        //        ForeignName = "Tuloc HCM tech Vietnam",
        //        LogoURL = "https://testurl.com/corp001.png",
        //        Name = "Chi nhanh HCM",
        //        PhoneNumber = "0936915227",
        //        ShortName = "VNT HCM Tech",
        //        TaxCode = "123456789",
        //        CompanyId = companyid,
        //        DistrictId = 1,
        //        CreatedByUserId = system.Id,
        //        CreatedByUserName = system.UserName,
        //        UpdatedByUserId = system.Id,
        //        UpdatedByUserName = system.UserName,
        //    };
        //    await dbContext.AddAsync(model);
        //    await dbContext.SaveChangesAsync();
        //    Console.WriteLine("Finished seed Branch");
        //    return model.Id;
        //}

        //private static async Task<int> SeedDepartmentAsync(ApplicationDbContext dbContext, int branchId)
        //{
        //    Console.WriteLine("Start to seed Department");
        //    var userManagement = _serviceProvider.GetService<UserManager<User>>();
        //    var system = userManagement.FindByNameAsync("sysadmin").Result;
        //    var model = new Department
        //    {
        //        Code = "VNT",
        //        Email = "department@gmail.com",
        //        Name = "Department",
        //        PhoneNumber = "0936915227",
        //        BranchId = branchId,
        //        CreatedByUserId = system.Id,
        //        CreatedByUserName = system.UserName,
        //        UpdatedByUserId = system.Id,
        //        UpdatedByUserName = system.UserName,
        //    };
        //    await dbContext.AddAsync(model);
        //    await dbContext.SaveChangesAsync();
        //    Console.WriteLine("Finished seed Department");
        //    return model.Id;
        //}

        private static async Task<int> SeedProvinceAsync(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Start to seed Province");
            var userManagement = _serviceProvider.GetService<UserManager<User>>();
            var system = userManagement.FindByNameAsync("sysadmin").Result;
            var model = new Province
            {
                Code = "01",
                Name = "Thành Phố Hồ Chí Minh",
                Type = "Thành Phố",
                CreatedByUserId = system.Id,
                CreatedByUserName = system.UserName,
                UpdatedByUserId = system.Id,
                UpdatedByUserName = system.UserName,
            };
            await dbContext.AddAsync(model);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Finished seed Province");
            return model.Id;
        }

        private static async Task<int> SeedDistrictAsync(ApplicationDbContext dbContext, int provinceId)
        {
            Console.WriteLine("Start to seed District");
            var userManagement = _serviceProvider.GetService<UserManager<User>>();
            var system = userManagement.FindByNameAsync("sysadmin").Result;
            var model = new District
            {
                Code = "01",
                Name = "Quận Bình Thạnh",
                Type = "Quận",
                ProvinceId = provinceId,
                CreatedByUserId = system.Id,
                CreatedByUserName = system.UserName,
                UpdatedByUserId = system.Id,
                UpdatedByUserName = system.UserName,
            };
            await dbContext.AddAsync(model);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Finished seed District");
            return model.Id;
        }
     

        private static async Task SeedEmailTemplate(ApplicationDbContext dbContext)
        {
            List<EmailTemplate> emailTemplates = new List<EmailTemplate>();
            emailTemplates.Add(new EmailTemplate()
            {
                Name = "NewUserEmail",
                EmailContent = "<span>" +
                "Xin chào #email<br /><br />" +
                "Dưới đây là thông tin đăng nhập của bạn vào hệ thống của chúng tôi:<br />" +
                "Tên đăng nhập: <b />#username</b><br />" +
                "Mật khẩu: <b />#password</b><br />" +
                "Để an toàn cho việc đăng nhập vào hệ thống, bạn vui lòng đăng nhập vào hệ thống và sử dụng chức năng đổi mật khẩu.<br /><br />" +
                "Xin cảm ơn,<br />" +
                "Agrifood support" +
                "</span> ",
                EmailSubject = "Thông tin đăng nhập hệ thống [Agrifood.vn]"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Name = "ResetUserPasswordEmail",
                EmailContent = "<span>" +
                "Xin chào <b>#email</b>,<br /><br />" +
                "Mật khẩu cho tài khoản <b>#username</b> của bạn đã thay đổi:<br />" +
                "Mật khẩu mới: <b>#password</b><br />" +
                "Để an toàn cho việc đăng nhập vào hệ thống," +
                "bạn vui lòng đăng nhập vào hệ thống và sử dụng chức năng đổi mật khẩu.<br /><br />" +
                "Xin cảm ơn,<br />" +
                "Agrifood Support" +
                "</ span > ",
                EmailSubject = "Khôi phục mật khẩu đăng nhập hệ thống [Agrifood.vn]"
            });
            emailTemplates.Add(new EmailTemplate()
            {
                Name = "ChangeUserPasswordEmail",
                EmailContent = "<span>" +
                "Xin chào <b>#email</b>,<br /><br />" +
                "Mật khẩu cho tài khoản <b>#username</b> của bạn đã thay đổi.<br /><br />" +
                "Xin cảm ơn,<br />" +
                "Agrifood support" +
                "</ span > ",
                EmailSubject = "Thay đổi mật khẩu đăng nhập hệ thống [Agrifood.vn]"
            });
            dbContext.AddRange(emailTemplates);
            await dbContext.SaveChangesAsync();
        }


    
















   
    }
}
