﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.DbMigration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201229070518_CreateEmployeeEntity")]
    partial class CreateEmployeeEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AppelationOfForeignTrader");

                    b.Property<string>("Code");

                    b.Property<int>("CompanyId");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<int>("DistrictId");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("ForeignName");

                    b.Property<string>("LogoURL");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("ShortName");

                    b.Property<string>("TaxCode");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Byre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<int>("FarmerId");

                    b.Property<int>("QuantityCow");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("FarmerId");

                    b.ToTable("Byre");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AppelationOfForeignTrader");

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FacebookName");

                    b.Property<string>("Fax");

                    b.Property<string>("ForeignName");

                    b.Property<string>("LogoURL");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("RepresentativeId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("ShortName");

                    b.Property<string>("StampURL");

                    b.Property<string>("TaxCode");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<string>("WebsiteURL");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId");

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Remarks");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("ShortName");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<int>("ProvinceId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("Type");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber");

                    b.Property<string>("Address");

                    b.Property<string>("Bank");

                    b.Property<string>("BankBranch");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("IdentificationNo");

                    b.Property<string>("IssuedBy");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<string>("Name");

                    b.Property<string>("PermissionGroup");

                    b.Property<string>("PhoneNumber");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<int>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Farmer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AvatarURL");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Code");

                    b.Property<DateTime>("ContractCreatetionDate");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<int?>("DistrictId");

                    b.Property<string>("FullName");

                    b.Property<bool>("Gender");

                    b.Property<bool>("IsBlock");

                    b.Property<int?>("MilkCollectionStationId");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("ProvinceId");

                    b.Property<string>("QrCode");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Farmer");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("Type");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("ApplicationDomain.Core.Entities.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("EmailContent");

                    b.Property<string>("EmailSubject");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("EmailTemplate");
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.MenuPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AssetMenu");

                    b.Property<bool>("BillMenu");

                    b.Property<bool>("ContractTemplateMenu");

                    b.Property<bool>("ContractsMenu");

                    b.Property<bool>("CreateContractMenu");

                    b.Property<bool>("CreateOrderMenu");

                    b.Property<bool>("CreateQuotationMenu");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 63, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)));

                    b.Property<bool>("CustomerLibraryMenu");

                    b.Property<bool>("CustomerQuotaionMenu");

                    b.Property<bool>("DistrictLibraryMenu");

                    b.Property<bool>("HRMMenu");

                    b.Property<bool>("InventoryMenu");

                    b.Property<bool>("LibraryMenu");

                    b.Property<bool>("MonthlyReportQuotaionMenu");

                    b.Property<bool>("OrderReportMenu");

                    b.Property<bool>("OrdersMenu");

                    b.Property<bool>("OtherMenu");

                    b.Property<int>("PermissionGroupId");

                    b.Property<bool>("PurchaseMenu");

                    b.Property<bool>("QuotationsMenu");

                    b.Property<byte[]>("RowVersion");

                    b.Property<bool>("RulesQuotationMenu");

                    b.Property<bool>("ServiceMenu");

                    b.Property<bool>("ShippingCostQuotationMenu");

                    b.Property<bool>("StructureMenu");

                    b.Property<bool>("SummarizeReportQuotaionMenu");

                    b.Property<bool>("SystemMenu");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 67, DateTimeKind.Unspecified).AddTicks(9608), new TimeSpan(0, 7, 0, 0, 0)));

                    b.Property<bool>("UserMenu");

                    b.HasKey("Id");

                    b.HasIndex("PermissionGroupId");

                    b.ToTable("MenuPermission");
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.PermissionGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 71, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 7, 0, 0, 0)));

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 71, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)));

                    b.HasKey("Id");

                    b.ToTable("PermissionGroup");
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.PermissionMembership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 75, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)));

                    b.Property<int>("PermissionGroupId");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 75, DateTimeKind.Unspecified).AddTicks(4141), new TimeSpan(0, 7, 0, 0, 0)));

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("PermissionMembership");
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName")
                        .IsRequired();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AvatarURL");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("CreatedByUserName")
                        .IsRequired();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NetResetCode");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ResetCode");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("UpdatedByUserName")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedDate");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Branch", b =>
                {
                    b.HasOne("ApplicationDomain.BOA.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApplicationDomain.BOA.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Byre", b =>
                {
                    b.HasOne("ApplicationDomain.BOA.Entities.Farmer", "Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Department", b =>
                {
                    b.HasOne("ApplicationDomain.BOA.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.District", b =>
                {
                    b.HasOne("ApplicationDomain.BOA.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Employee", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomain.BOA.Entities.Farmer", b =>
                {
                    b.HasOne("ApplicationDomain.BOA.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("ApplicationDomain.BOA.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.HasOne("ApplicationDomain.Identity.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("ApplicationDomain.BOA.Entities.Farmer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.MenuPermission", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.PermissionGroup", "PermissionGroup")
                        .WithMany()
                        .HasForeignKey("PermissionGroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ApplicationDomain.Identity.Entities.PermissionMembership", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.PermissionGroup", "PermissionGroup")
                        .WithMany()
                        .HasForeignKey("PermissionGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApplicationDomain.Identity.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApplicationDomain.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ApplicationDomain.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
