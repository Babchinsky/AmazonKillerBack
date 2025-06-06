using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                column: "ImageUrls",
                value: "[\"https://content.rozetka.com.ua/goods/images/big/398092199.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/398092200.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092201.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092202.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092203.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/398092204.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/398092205.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092206.jpg\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                column: "ImageUrls",
                value: "[\"https://example.com/products/samsung1.jpg\",\"https://example.com/products/samsung2.jpg\"]");
        }
    }
}
