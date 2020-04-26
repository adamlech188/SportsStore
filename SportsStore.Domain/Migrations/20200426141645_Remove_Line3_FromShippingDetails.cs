using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Domain.Migrations
{
    public partial class Remove_Line3_FromShippingDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line3",
                table: "ShippingDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Line3",
                table: "ShippingDetails",
                type: "text",
                nullable: true);
        }
    }
}
