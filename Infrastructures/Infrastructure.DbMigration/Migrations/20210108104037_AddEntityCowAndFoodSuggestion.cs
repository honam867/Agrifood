using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class AddEntityCowAndFoodSuggestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerPermission_PermissionGroup_PermissionGroupId",
                table: "FarmerPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 715, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 714, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7243), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7068), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7245), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 460, DateTimeKind.Unspecified).AddTicks(1812), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 698, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 455, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 694, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "FoodSuggestion",
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
                    CowId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSuggestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cow",
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
                    ByreId = table.Column<int>(nullable: false),
                    MotherId = table.Column<int>(nullable: false),
                    FatherId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QRCode = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    AgeNumber = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    WeaningDate = table.Column<DateTime>(nullable: false),
                    FoodSuggestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cow_Byre_ByreId",
                        column: x => x.ByreId,
                        principalTable: "Byre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cow_FoodSuggestion_FoodSuggestionId",
                        column: x => x.FoodSuggestionId,
                        principalTable: "FoodSuggestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cow_ByreId",
                table: "Cow",
                column: "ByreId");

            migrationBuilder.CreateIndex(
                name: "IX_Cow_FoodSuggestionId",
                table: "Cow",
                column: "FoodSuggestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSuggestion_CowId",
                table: "FoodSuggestion",
                column: "CowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerPermission_PermissionGroup_PermissionGroupId",
                table: "FarmerPermission",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodSuggestion_Cow_CowId",
                table: "FoodSuggestion",
                column: "CowId",
                principalTable: "Cow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerPermission_PermissionGroup_PermissionGroupId",
                table: "FarmerPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_Cow_FoodSuggestion_FoodSuggestionId",
                table: "Cow");

            migrationBuilder.DropTable(
                name: "FoodSuggestion");

            migrationBuilder.DropTable(
                name: "Cow");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 715, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(1532), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 714, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 477, DateTimeKind.Unspecified).AddTicks(966), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7068), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 472, DateTimeKind.Unspecified).AddTicks(7243), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7245), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 471, DateTimeKind.Unspecified).AddTicks(7623), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 698, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 460, DateTimeKind.Unspecified).AddTicks(1812), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 694, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 8, 2, 40, 36, 455, DateTimeKind.Unspecified).AddTicks(4848), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerPermission_PermissionGroup_PermissionGroupId",
                table: "FarmerPermission",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
