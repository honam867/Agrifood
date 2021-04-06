using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateFamerAndCow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeNumber",
                table: "Cow");

            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "Cow");

            migrationBuilder.RenameColumn(
                name: "QrCode",
                table: "Farmer",
                newName: "IssuedBy");

            migrationBuilder.RenameColumn(
                name: "AvatarURL",
                table: "Farmer",
                newName: "IdentificationNo");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 303, DateTimeKind.Unspecified).AddTicks(2110), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 547, DateTimeKind.Unspecified).AddTicks(4027), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 303, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 547, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 299, DateTimeKind.Unspecified).AddTicks(563), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 516, DateTimeKind.Unspecified).AddTicks(8073), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 299, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 516, DateTimeKind.Unspecified).AddTicks(5594), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 298, DateTimeKind.Unspecified).AddTicks(853), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 511, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 298, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 511, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 276, DateTimeKind.Unspecified).AddTicks(9785), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 191, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 270, DateTimeKind.Unspecified).AddTicks(5697), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 22, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Farmer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Farmer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankBranch",
                table: "Farmer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedOn",
                table: "Farmer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Farmer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_MilkCollectionStationId",
                table: "Farmer",
                column: "MilkCollectionStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_WareHouseId",
                table: "Farmer",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmer_MilkCollectionStation_MilkCollectionStationId",
                table: "Farmer",
                column: "MilkCollectionStationId",
                principalTable: "MilkCollectionStation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Farmer_Warehouse_WareHouseId",
                table: "Farmer",
                column: "WareHouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmer_MilkCollectionStation_MilkCollectionStationId",
                table: "Farmer");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmer_Warehouse_WareHouseId",
                table: "Farmer");

            migrationBuilder.DropIndex(
                name: "IX_Farmer_MilkCollectionStationId",
                table: "Farmer");

            migrationBuilder.DropIndex(
                name: "IX_Farmer_WareHouseId",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "BankBranch",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "IssuedOn",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Farmer");

            migrationBuilder.RenameColumn(
                name: "IssuedBy",
                table: "Farmer",
                newName: "QrCode");

            migrationBuilder.RenameColumn(
                name: "IdentificationNo",
                table: "Farmer",
                newName: "AvatarURL");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 547, DateTimeKind.Unspecified).AddTicks(4027), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 303, DateTimeKind.Unspecified).AddTicks(2110), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 547, DateTimeKind.Unspecified).AddTicks(1442), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 303, DateTimeKind.Unspecified).AddTicks(1637), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 516, DateTimeKind.Unspecified).AddTicks(8073), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 299, DateTimeKind.Unspecified).AddTicks(563), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 516, DateTimeKind.Unspecified).AddTicks(5594), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 299, DateTimeKind.Unspecified).AddTicks(121), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 511, DateTimeKind.Unspecified).AddTicks(6803), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 298, DateTimeKind.Unspecified).AddTicks(853), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 511, DateTimeKind.Unspecified).AddTicks(4508), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 298, DateTimeKind.Unspecified).AddTicks(352), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 191, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 276, DateTimeKind.Unspecified).AddTicks(9785), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 17, 47, 32, 22, DateTimeKind.Unspecified).AddTicks(8433), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 6, 20, 10, 28, 270, DateTimeKind.Unspecified).AddTicks(5697), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "AgeNumber",
                table: "Cow",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QRCode",
                table: "Cow",
                nullable: true);
        }
    }
}
