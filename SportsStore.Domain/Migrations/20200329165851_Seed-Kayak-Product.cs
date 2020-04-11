using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Domain.Migrations
{
    public partial class SeedKayakProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "A boat for one person", "Kayak", 275.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 9, 1, "Gold-plated, diamond-studded King", "Bling-Bling King", 1200.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Gold-plated, diamond-studded King", "Bling-Bling King", 1200.00m });
        }
    }
}
