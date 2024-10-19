using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1SphinxCommercial.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamingProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "ProductID");
        }
    }
}
