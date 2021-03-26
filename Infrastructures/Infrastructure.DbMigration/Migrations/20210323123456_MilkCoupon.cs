using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DbMigration.Migrations
{
    public partial class MilkCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 971, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 196, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 970, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 196, DateTimeKind.Unspecified).AddTicks(6504), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(2487), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(1587), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(2057), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 955, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 182, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 950, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 178, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "MilkCoupon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserName = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    FarmerId = table.Column<int>(nullable: false),
                    ScaleCode = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    StorageTankCode = table.Column<string>(nullable: true),
                    Session = table.Column<string>(nullable: true),
                    MilkCollectionStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilkCoupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilkCoupon_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MilkCoupon_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MilkCoupon_MilkCollectionStation_MilkCollectionStationId",
                        column: x => x.MilkCollectionStationId,
                        principalTable: "MilkCollectionStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilkCoupon_EmployeeId",
                table: "MilkCoupon",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MilkCoupon_FarmerId",
                table: "MilkCoupon",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_MilkCoupon_MilkCollectionStationId",
                table: "MilkCoupon",
                column: "MilkCollectionStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilkCoupon");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 196, DateTimeKind.Unspecified).AddTicks(6895), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 971, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionMembership",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 196, DateTimeKind.Unspecified).AddTicks(6504), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 970, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(9458), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PermissionGroup",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(9062), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(2487), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "MenuPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 192, DateTimeKind.Unspecified).AddTicks(2057), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 966, DateTimeKind.Unspecified).AddTicks(1587), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 182, DateTimeKind.Unspecified).AddTicks(8156), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 955, DateTimeKind.Unspecified).AddTicks(1865), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FarmerPermission",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 6, 14, 0, 38, 178, DateTimeKind.Unspecified).AddTicks(5679), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 23, 19, 34, 55, 950, DateTimeKind.Unspecified).AddTicks(4770), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
