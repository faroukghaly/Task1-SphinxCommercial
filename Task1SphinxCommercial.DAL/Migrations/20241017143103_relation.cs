﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1SphinxCommercial.DAL.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientProducts_ProductId",
                table: "ClientProducts",
                column: "ProductId");

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

            migrationBuilder.DropIndex(
                name: "IX_ClientProducts_ProductId",
                table: "ClientProducts");
        }
    }
}
