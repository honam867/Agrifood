using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class CreateEmployeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 75, DateTimeKind.Unspecified).AddTicks(4141), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 426, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 75, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 426, DateTimeKind.Unspecified).AddTicks(6922), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 71, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 422, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 71, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 422, DateTimeKind.Unspecified).AddTicks(7299), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 67, DateTimeKind.Unspecified).AddTicks(9608), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 419, DateTimeKind.Unspecified).AddTicks(4282), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 63, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 414, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Byre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    QuantityCow = table.Column<int>(nullable: false),
                    FarmerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Byre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Byre_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    IdentificationNo = table.Column<string>(nullable: true),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<int>(nullable: false),
                    Bank = table.Column<string>(nullable: true),
                    BankBranch = table.Column<string>(nullable: true),
                    PermissionGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Byre_FarmerId",
                table: "Byre",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserId",
                table: "Employee",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Byre");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 426, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 75, DateTimeKind.Unspecified).AddTicks(4141), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 426, DateTimeKind.Unspecified).AddTicks(6922), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 75, DateTimeKind.Unspecified).AddTicks(3781), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 422, DateTimeKind.Unspecified).AddTicks(7705), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 71, DateTimeKind.Unspecified).AddTicks(8003), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 422, DateTimeKind.Unspecified).AddTicks(7299), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 71, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 419, DateTimeKind.Unspecified).AddTicks(4282), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 67, DateTimeKind.Unspecified).AddTicks(9608), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 14, 10, 11, 33, 414, DateTimeKind.Unspecified).AddTicks(8942), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 14, 5, 18, 63, DateTimeKind.Unspecified).AddTicks(5772), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
