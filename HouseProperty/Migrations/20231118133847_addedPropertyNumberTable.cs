using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseProperty.Migrations
{
    /// <inheritdoc />
    public partial class addedPropertyNumberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyNumber",
                columns: table => new
                {
                    PropertyNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyNumber", x => x.PropertyNo);
                    table.ForeignKey(
                        name: "FK_PropertyNumber_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.CreateIndex(
                name: "IX_PropertyNumber_PropertyID",
                table: "PropertyNumber",
                column: "PropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyNumber");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 15, 23, 46, 6, 18, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 15, 23, 46, 6, 18, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 15, 23, 46, 6, 18, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 15, 23, 46, 6, 18, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 15, 23, 46, 6, 18, DateTimeKind.Local).AddTicks(195));
        }
    }
}
