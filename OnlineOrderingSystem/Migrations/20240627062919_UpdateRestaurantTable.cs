using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Address_Tbl_Restaurant_AddressID",
                table: "Tbl_Address");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "626e7a24-ff07-4fda-9abe-d28e700eb2e9");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f3d4959b-95a6-4592-8ed0-23efbe5c4975");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Tbl_Restaurant");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tbl_Restaurant",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "439cb04c-0199-4389-ba52-10f8bb6b6e62", null, "admin", "Admin" },
                    { "56e7566a-1a4c-40f7-82b9-ece20ced39a1", null, "client", "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "439cb04c-0199-4389-ba52-10f8bb6b6e62");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "56e7566a-1a4c-40f7-82b9-ece20ced39a1");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tbl_Restaurant");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "Tbl_Restaurant",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "626e7a24-ff07-4fda-9abe-d28e700eb2e9", null, "client", "Client" },
                    { "f3d4959b-95a6-4592-8ed0-23efbe5c4975", null, "admin", "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Address_Tbl_Restaurant_AddressID",
                table: "Tbl_Address",
                column: "AddressID",
                principalTable: "Tbl_Restaurant",
                principalColumn: "RestaurantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
