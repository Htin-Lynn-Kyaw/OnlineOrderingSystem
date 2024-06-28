using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7caa3b06-eceb-4ce6-a132-d320558937e6");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9360f328-2e76-405d-8a01-a2c4002ce61c");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressID",
                table: "Tbl_Restaurant",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "626e7a24-ff07-4fda-9abe-d28e700eb2e9", null, "client", "Client" },
                    { "f3d4959b-95a6-4592-8ed0-23efbe5c4975", null, "admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "626e7a24-ff07-4fda-9abe-d28e700eb2e9");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f3d4959b-95a6-4592-8ed0-23efbe5c4975");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressID",
                table: "Tbl_Restaurant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7caa3b06-eceb-4ce6-a132-d320558937e6", null, "client", "Client" },
                    { "9360f328-2e76-405d-8a01-a2c4002ce61c", null, "admin", "Admin" }
                });
        }
    }
}
