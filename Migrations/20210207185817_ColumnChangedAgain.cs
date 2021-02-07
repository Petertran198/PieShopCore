using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class ColumnChangedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartID",
                table: "ShoppingCartItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartItemID",
                table: "ShoppingCartItems",
                newName: "ShoppingCartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                newName: "ShoppingCartID");
        }
    }
}
