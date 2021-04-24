using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateAllDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "MenuPermission");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 559, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 591, DateTimeKind.Unspecified).AddTicks(4900), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 558, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 591, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 555, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 587, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 550, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 587, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 547, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 571, DateTimeKind.Unspecified).AddTicks(8392), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 542, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 566, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 591, DateTimeKind.Unspecified).AddTicks(4900), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 559, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 591, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 558, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 587, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 555, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 587, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 550, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 571, DateTimeKind.Unspecified).AddTicks(8392), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 547, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 566, DateTimeKind.Unspecified).AddTicks(9529), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 542, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AppelationOfForeignTrader = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FacebookName = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    ForeignName = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RepresentativeId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    StampURL = table.Column<string>(nullable: true),
                    TaxCode = table.Column<string>(nullable: true),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    WebsiteURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetMenu = table.Column<bool>(nullable: false),
                    BillMenu = table.Column<bool>(nullable: false),
                    ContractTemplateMenu = table.Column<bool>(nullable: false),
                    ContractsMenu = table.Column<bool>(nullable: false),
                    CreateContractMenu = table.Column<bool>(nullable: false),
                    CreateOrderMenu = table.Column<bool>(nullable: false),
                    CreateQuotationMenu = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 586, DateTimeKind.Unspecified).AddTicks(6779), new TimeSpan(0, 7, 0, 0, 0))),
                    CustomerLibraryMenu = table.Column<bool>(nullable: false),
                    CustomerQuotaionMenu = table.Column<bool>(nullable: false),
                    DistrictLibraryMenu = table.Column<bool>(nullable: false),
                    HRMMenu = table.Column<bool>(nullable: false),
                    InventoryMenu = table.Column<bool>(nullable: false),
                    LibraryMenu = table.Column<bool>(nullable: false),
                    MonthlyReportQuotaionMenu = table.Column<bool>(nullable: false),
                    OrderReportMenu = table.Column<bool>(nullable: false),
                    OrdersMenu = table.Column<bool>(nullable: false),
                    OtherMenu = table.Column<bool>(nullable: false),
                    PermissionGroupId = table.Column<int>(nullable: false),
                    PurchaseMenu = table.Column<bool>(nullable: false),
                    QuotationsMenu = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    RulesQuotationMenu = table.Column<bool>(nullable: false),
                    ServiceMenu = table.Column<bool>(nullable: false),
                    ShippingCostQuotationMenu = table.Column<bool>(nullable: false),
                    StructureMenu = table.Column<bool>(nullable: false),
                    SummarizeReportQuotaionMenu = table.Column<bool>(nullable: false),
                    SystemMenu = table.Column<bool>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 10, 17, 32, 56, 586, DateTimeKind.Unspecified).AddTicks(7287), new TimeSpan(0, 7, 0, 0, 0))),
                    UserMenu = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPermission_PermissionGroup_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AppelationOfForeignTrader = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    ForeignName = table.Column<string>(nullable: true),
                    LogoURL = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    TaxCode = table.Column<string>(nullable: true),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branch_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyId",
                table: "Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_DistrictId",
                table: "Branch",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_BranchId",
                table: "Department",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_PermissionGroupId",
                table: "MenuPermission",
                column: "PermissionGroupId");
        }
    }
}
