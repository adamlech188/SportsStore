using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Domain.Migrations
{
    public partial class SeedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Watersports" },
                    { 2, "Soccer" },
                    { 3, "Chess" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
