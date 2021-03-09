using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateCow2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 937, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 775, DateTimeKind.Unspecified).AddTicks(5251), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 937, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 775, DateTimeKind.Unspecified).AddTicks(4795), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 929, DateTimeKind.Unspecified).AddTicks(8877), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 769, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 929, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 769, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 928, DateTimeKind.Unspecified).AddTicks(4571), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 768, DateTimeKind.Unspecified).AddTicks(5067), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 928, DateTimeKind.Unspecified).AddTicks(3905), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 768, DateTimeKind.Unspecified).AddTicks(4502), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 914, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 755, DateTimeKind.Unspecified).AddTicks(1660), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 907, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 750, DateTimeKind.Unspecified).AddTicks(1981), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Cow",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TinhCode",
                table: "Cow",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cow");

            migrationBuilder.DropColumn(
                name: "TinhCode",
                table: "Cow");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 775, DateTimeKind.Unspecified).AddTicks(5251), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 937, DateTimeKind.Unspecified).AddTicks(5306), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 775, DateTimeKind.Unspecified).AddTicks(4795), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 937, DateTimeKind.Unspecified).AddTicks(4411), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 769, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 929, DateTimeKind.Unspecified).AddTicks(8877), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 769, DateTimeKind.Unspecified).AddTicks(4555), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 929, DateTimeKind.Unspecified).AddTicks(8145), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 768, DateTimeKind.Unspecified).AddTicks(5067), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 928, DateTimeKind.Unspecified).AddTicks(4571), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 768, DateTimeKind.Unspecified).AddTicks(4502), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 928, DateTimeKind.Unspecified).AddTicks(3905), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 755, DateTimeKind.Unspecified).AddTicks(1660), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 914, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 10, 3, 750, DateTimeKind.Unspecified).AddTicks(1981), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 13, 32, 8, 907, DateTimeKind.Unspecified).AddTicks(4581), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
