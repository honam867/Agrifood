using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateFoodSuggestionV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodSuggestion_Food_Foodid",
                table: "FoodSuggestion");

            migrationBuilder.RenameColumn(
                name: "Foodid",
                table: "FoodSuggestion",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodSuggestion_Foodid",
                table: "FoodSuggestion",
                newName: "IX_FoodSuggestion_FoodId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 211, DateTimeKind.Unspecified).AddTicks(2202), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 742, DateTimeKind.Unspecified).AddTicks(817), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 211, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 742, DateTimeKind.Unspecified).AddTicks(217), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 207, DateTimeKind.Unspecified).AddTicks(3438), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 737, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 207, DateTimeKind.Unspecified).AddTicks(2875), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 737, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 200, DateTimeKind.Unspecified).AddTicks(1407), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 727, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 195, DateTimeKind.Unspecified).AddTicks(3562), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 721, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FoodSuggestion_Food_FoodId",
                table: "FoodSuggestion",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodSuggestion_Food_FoodId",
                table: "FoodSuggestion");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "FoodSuggestion",
                newName: "Foodid");

            migrationBuilder.RenameIndex(
                name: "IX_FoodSuggestion_FoodId",
                table: "FoodSuggestion",
                newName: "IX_FoodSuggestion_Foodid");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 742, DateTimeKind.Unspecified).AddTicks(817), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 211, DateTimeKind.Unspecified).AddTicks(2202), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 742, DateTimeKind.Unspecified).AddTicks(217), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 211, DateTimeKind.Unspecified).AddTicks(1802), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 737, DateTimeKind.Unspecified).AddTicks(2330), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 207, DateTimeKind.Unspecified).AddTicks(3438), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 737, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 207, DateTimeKind.Unspecified).AddTicks(2875), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 727, DateTimeKind.Unspecified).AddTicks(6519), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 200, DateTimeKind.Unspecified).AddTicks(1407), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 4, 52, 721, DateTimeKind.Unspecified).AddTicks(2841), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 4, 25, 13, 14, 56, 195, DateTimeKind.Unspecified).AddTicks(3562), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FoodSuggestion_Food_Foodid",
                table: "FoodSuggestion",
                column: "Foodid",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
