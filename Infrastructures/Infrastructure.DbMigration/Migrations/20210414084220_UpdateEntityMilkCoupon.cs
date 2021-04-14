using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateEntityMilkCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScaleCode",
                table: "MilkCoupon");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 813, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 559, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 813, DateTimeKind.Unspecified).AddTicks(7232), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 558, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 810, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 555, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 809, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 550, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "TypeMilk",
                table: "MilkCouponDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "MilkQuality",
                table: "MilkCouponDetail",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MilkCoupon",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 801, DateTimeKind.Unspecified).AddTicks(6837), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 547, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 797, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 542, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MilkQuality",
                table: "MilkCouponDetail");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 559, DateTimeKind.Unspecified).AddTicks(249), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 813, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 558, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 813, DateTimeKind.Unspecified).AddTicks(7232), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 555, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 810, DateTimeKind.Unspecified).AddTicks(398), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 550, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 809, DateTimeKind.Unspecified).AddTicks(9972), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "TypeMilk",
                table: "MilkCouponDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MilkCoupon",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AddColumn<string>(
                name: "ScaleCode",
                table: "MilkCoupon",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 547, DateTimeKind.Unspecified).AddTicks(3752), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 801, DateTimeKind.Unspecified).AddTicks(6837), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 12, 18, 0, 18, 542, DateTimeKind.Unspecified).AddTicks(3080), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 14, 15, 42, 19, 797, DateTimeKind.Unspecified).AddTicks(5063), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
