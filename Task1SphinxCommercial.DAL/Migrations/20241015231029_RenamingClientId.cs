using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1SphinxCommercial.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamingClientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Clients",
                newName: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "ClientID");
        }
    }
}
