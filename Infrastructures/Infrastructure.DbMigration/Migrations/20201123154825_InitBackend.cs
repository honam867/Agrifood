using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class InitBackend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 373, DateTimeKind.Unspecified).AddTicks(6951), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 373, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(9364), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 370, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 370, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 556, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 366, DateTimeKind.Unspecified).AddTicks(8104), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 552, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 362, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 373, DateTimeKind.Unspecified).AddTicks(6951), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 373, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 370, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(9364), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 370, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 366, DateTimeKind.Unspecified).AddTicks(8104), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 556, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 2, 0, 5, 7, 362, DateTimeKind.Unspecified).AddTicks(6755), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 552, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
