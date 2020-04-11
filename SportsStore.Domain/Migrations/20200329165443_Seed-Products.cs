using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Domain.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Gold-plated, diamond-studded King", "Bling-Bling King", 1200.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 2, 1, "Protective and fashionable", "Lifejacket", 48.95m },
                    { 3, 2, "FIFA-approved size and weight", "Soccer Ball", 19.50m },
                    { 4, 2, "Give your playing field a professional touch", "Corner Flags", 34.95m },
                    { 5, 2, "Flat-packed 35000-seat stadium", "Stadium", 79500m },
                    { 6, 3, "Improve your brain efficiency by 75%", "Thinking Cap", 16.00m },
                    { 7, 3, "Secretly give your opponent a disadvantage", "Unsteady Chair", 29.950m },
                    { 8, 3, "A fun game for the family", "Human Chess Board", 75.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "A boat for one person", "Kayak", 275.00m });
        }
    }
}
