using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SportsStore.Domain.Migrations
{
    public partial class Adding_ShippingDetailsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingDetails",
                columns: table => new
                {
                    ShippingDetailsID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    Line3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    GiftWrap = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDetails", x => x.ShippingDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "ProductShippingDetails",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    ShippingDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShippingDetails", x => new { x.ProductID, x.ShippingDetailsID });
                    table.ForeignKey(
                        name: "FK_ProductShippingDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShippingDetails_ShippingDetails_ShippingDetailsID",
                        column: x => x.ShippingDetailsID,
                        principalTable: "ShippingDetails",
                        principalColumn: "ShippingDetailsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductShippingDetails_ShippingDetailsID",
                table: "ProductShippingDetails",
                column: "ShippingDetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShippingDetails");

            migrationBuilder.DropTable(
                name: "ShippingDetails");
        }
    }
}
