using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateCodeEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 75, DateTimeKind.Unspecified).AddTicks(8084), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 652, DateTimeKind.Unspecified).AddTicks(7016), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 75, DateTimeKind.Unspecified).AddTicks(7727), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 652, DateTimeKind.Unspecified).AddTicks(6502), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 72, DateTimeKind.Unspecified).AddTicks(4118), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 648, DateTimeKind.Unspecified).AddTicks(8221), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 72, DateTimeKind.Unspecified).AddTicks(3743), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 648, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MilkCollectionStation",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 68, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 645, DateTimeKind.Unspecified).AddTicks(2994), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 64, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 640, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "MilkCollectionStation");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Employee");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 652, DateTimeKind.Unspecified).AddTicks(7016), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 75, DateTimeKind.Unspecified).AddTicks(8084), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 652, DateTimeKind.Unspecified).AddTicks(6502), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 75, DateTimeKind.Unspecified).AddTicks(7727), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 648, DateTimeKind.Unspecified).AddTicks(8221), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 72, DateTimeKind.Unspecified).AddTicks(4118), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 648, DateTimeKind.Unspecified).AddTicks(7851), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 72, DateTimeKind.Unspecified).AddTicks(3743), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 645, DateTimeKind.Unspecified).AddTicks(2994), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 68, DateTimeKind.Unspecified).AddTicks(8403), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 12, 29, 15, 51, 4, 640, DateTimeKind.Unspecified).AddTicks(8716), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 12, 31, 15, 31, 10, 64, DateTimeKind.Unspecified).AddTicks(2253), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
