using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseProperty.Migrations
{
    /// <inheritdoc />
    public partial class renamePropertyNumberToPropertyNumbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyNumber_Properties_PropertyID",
                table: "PropertyNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyNumber",
                table: "PropertyNumber");

            migrationBuilder.RenameTable(
                name: "PropertyNumber",
                newName: "PropertyNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyNumber_PropertyID",
                table: "PropertyNumbers",
                newName: "IX_PropertyNumbers_PropertyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyNumbers",
                table: "PropertyNumbers",
                column: "PropertyNo");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3443), new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3447), new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3450), new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3453), new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3451) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3455), new DateTime(2024, 2, 3, 15, 10, 45, 505, DateTimeKind.Local).AddTicks(3454) });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyNumbers_Properties_PropertyID",
                table: "PropertyNumbers",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyNumbers_Properties_PropertyID",
                table: "PropertyNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyNumbers",
                table: "PropertyNumbers");

            migrationBuilder.RenameTable(
                name: "PropertyNumbers",
                newName: "PropertyNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyNumbers_PropertyID",
                table: "PropertyNumber",
                newName: "IX_PropertyNumber_PropertyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyNumber",
                table: "PropertyNumber",
                column: "PropertyNo");

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5429), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5440), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5442), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5444), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 18, 19, 8, 47, 682, DateTimeKind.Local).AddTicks(5445), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyNumber_Properties_PropertyID",
                table: "PropertyNumber",
                column: "PropertyID",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
