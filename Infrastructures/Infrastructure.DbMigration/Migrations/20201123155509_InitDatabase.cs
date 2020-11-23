using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 606, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 606, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 602, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(9364), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 602, DateTimeKind.Unspecified).AddTicks(2438), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 599, DateTimeKind.Unspecified).AddTicks(581), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 556, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 594, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 552, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8647), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 606, DateTimeKind.Unspecified).AddTicks(1953), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 563, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 606, DateTimeKind.Unspecified).AddTicks(1547), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(9364), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 602, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 559, DateTimeKind.Unspecified).AddTicks(8949), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 602, DateTimeKind.Unspecified).AddTicks(2438), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 556, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 599, DateTimeKind.Unspecified).AddTicks(581), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 48, 25, 552, DateTimeKind.Unspecified).AddTicks(3009), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 11, 23, 22, 55, 9, 594, DateTimeKind.Unspecified).AddTicks(6028), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
