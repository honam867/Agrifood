using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class AddEntityByre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 715, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 662, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 714, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 662, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 655, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7068), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 654, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 653, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7245), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 653, DateTimeKind.Unspecified).AddTicks(4340), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 698, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 636, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 694, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 629, DateTimeKind.Unspecified).AddTicks(6068), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Breed",
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                });

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
                    Name = table.Column<string>(nullable: true),
                    BreedId = table.Column<int>(nullable: false),
                    QuantityCow = table.Column<int>(nullable: true),
                    FarmerId = table.Column<int>(nullable: false),
                    Ration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Byre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Byre_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Byre_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Byre_BreedId",
                table: "Byre",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Byre_FarmerId",
                table: "Byre",
                column: "FarmerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Byre");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 662, DateTimeKind.Unspecified).AddTicks(4285), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 715, DateTimeKind.Unspecified).AddTicks(446), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 662, DateTimeKind.Unspecified).AddTicks(3455), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 714, DateTimeKind.Unspecified).AddTicks(9955), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 655, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 654, DateTimeKind.Unspecified).AddTicks(9434), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 710, DateTimeKind.Unspecified).AddTicks(7068), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 653, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7818), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 653, DateTimeKind.Unspecified).AddTicks(4340), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 709, DateTimeKind.Unspecified).AddTicks(7245), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 636, DateTimeKind.Unspecified).AddTicks(5705), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 698, DateTimeKind.Unspecified).AddTicks(8132), new TimeSpan(0, -8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 2, 50, 30, 629, DateTimeKind.Unspecified).AddTicks(6068), new TimeSpan(0, -8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 7, 3, 28, 50, 694, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, -8, 0, 0, 0)));
        }
    }
}
