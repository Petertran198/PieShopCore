using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class ColumnChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopingCartItemID",
                table: "ShoppingCartItems",
                newName: "ShoppingCartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartItemId",
                table: "ShoppingCartItems",
                newName: "ShopingCartItemID");
        }
    }
}
