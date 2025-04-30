using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCartList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCards_CartLists_CartListId",
                table: "ProductCards");

            migrationBuilder.DropIndex(
                name: "IX_ProductCards_CartListId",
                table: "ProductCards");

            migrationBuilder.DropColumn(
                name: "CartListId",
                table: "ProductCards");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CartLists",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "CartLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "CartLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartLists_ProductId",
                table: "CartLists",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLists_Products_ProductId",
                table: "CartLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLists_Products_ProductId",
                table: "CartLists");

            migrationBuilder.DropIndex(
                name: "IX_CartLists_ProductId",
                table: "CartLists");

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "CartLists");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartLists");

            migrationBuilder.AddColumn<Guid>(
                name: "CartListId",
                table: "ProductCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "CartLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCards_CartListId",
                table: "ProductCards",
                column: "CartListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCards_CartLists_CartListId",
                table: "ProductCards",
                column: "CartListId",
                principalTable: "CartLists",
                principalColumn: "Id");
        }
    }
}
