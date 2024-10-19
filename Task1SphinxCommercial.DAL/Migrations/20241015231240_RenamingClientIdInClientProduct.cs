using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1SphinxCommercial.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamingClientIdInClientProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Clients_ClientID",
                table: "ClientProducts");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "ClientProducts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProducts_ClientID",
                table: "ClientProducts",
                newName: "IX_ClientProducts_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientProducts",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_ClientProducts_ClientId",
                table: "ClientProducts",
                newName: "IX_ClientProducts_ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Clients_ClientID",
                table: "ClientProducts",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
