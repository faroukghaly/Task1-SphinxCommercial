using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1SphinxCommercial.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamingProductIdInClientProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Products_ProductID",
                table: "ClientProducts");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ClientProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProducts_ProductID",
                table: "ClientProducts",
                newName: "IX_ClientProducts_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ClientProducts",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProducts_ProductId",
                table: "ClientProducts",
                newName: "IX_ClientProducts_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Products_ProductID",
                table: "ClientProducts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
