using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class UpdateFoodSuggestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodSuggestion_Cow_CowId",
                table: "FoodSuggestion");

            migrationBuilder.DropIndex(
                name: "IX_FoodSuggestion_CowId",
                table: "FoodSuggestion");

            migrationBuilder.DropColumn(
                name: "CowId",
                table: "FoodSuggestion");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 448, DateTimeKind.Unspecified).AddTicks(9702), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 448, DateTimeKind.Unspecified).AddTicks(9144), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 444, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 444, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7243), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 443, DateTimeKind.Unspecified).AddTicks(4920), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 443, DateTimeKind.Unspecified).AddTicks(4365), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "FoodSuggestion",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 432, DateTimeKind.Unspecified).AddTicks(7590), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 460, DateTimeKind.Unspecified).AddTicks(1812), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 427, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 455, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, -8, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "FoodSuggestion");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 448, DateTimeKind.Unspecified).AddTicks(9702), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 448, DateTimeKind.Unspecified).AddTicks(9144), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 444, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7243), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 444, DateTimeKind.Unspecified).AddTicks(4524), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 443, DateTimeKind.Unspecified).AddTicks(4920), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 443, DateTimeKind.Unspecified).AddTicks(4365), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "CowId",
                table: "FoodSuggestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 460, DateTimeKind.Unspecified).AddTicks(1812), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 432, DateTimeKind.Unspecified).AddTicks(7590), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 455, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 12, 20, 16, 32, 427, DateTimeKind.Unspecified).AddTicks(9730), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_FoodSuggestion_CowId",
                table: "FoodSuggestion",
                column: "CowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodSuggestion_Cow_CowId",
                table: "FoodSuggestion",
                column: "CowId",
                principalTable: "Cow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
