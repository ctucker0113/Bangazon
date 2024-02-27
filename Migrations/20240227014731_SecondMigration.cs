using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Name", "Price", "Quantity", "SellerID", "TimePosted" },
                values: new object[] { 3, 2, "For those who prefer fast internet speeds and don't mind the ugly look of cables", "Ethernet Cable", 30.00m, 2, 1, new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
