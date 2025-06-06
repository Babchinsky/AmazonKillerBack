using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"),
                column: "IconName",
                value: "sofa");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"),
                column: "IconName",
                value: "hanger");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"),
                column: "IconName",
                value: "computer");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8980e70c-3345-4885-8518-cfcda95b3078"),
                column: "IconName",
                value: "cleaning-spray");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                column: "PropertyKeys",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
                column: "IconName",
                value: "hammer");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
                column: "ImageUrls",
                value: "[\"https://content2.rozetka.com.ua/goods/images/big/333625233.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/367185899.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
                column: "ImageUrls",
                value: "[\"https://cdn2.jysk.com/getimage/wd3.medium/256592\",\"https://cdn2.jysk.com/getimage/wd3.medium/254304\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
                column: "ImageUrls",
                value: "[\"https://content1.rozetka.com.ua/goods/images/big/396437112.jpg\",\"https://content.rozetka.com.ua/goods/images/big/396437105.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/396437106.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                column: "ImageUrls",
                value: "[\"https://xcdn.next.co.uk/common/items/default/default/itemimages/3_4Ratio/product/lge/E66531s.jpg?im=Resize,width=750\",\"https://xcdn.next.co.uk/common/items/default/default/itemimages/3_4Ratio/product/lge/E66531s3.jpg?im=Resize,width=480\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"),
                column: "IconName",
                value: "furniture");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"),
                column: "IconName",
                value: "fashion");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"),
                column: "IconName",
                value: "electronics");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8980e70c-3345-4885-8518-cfcda95b3078"),
                column: "IconName",
                value: "household");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                column: "PropertyKeys",
                value: "[\"Type\",\"Noise Cancellation\",\"Battery Life\",\"Connectivity\"]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
                column: "IconName",
                value: "work tools");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
                column: "ImageUrls",
                value: "[\"https://example.com/products/makita1.jpg\",\"https://example.com/products/makita2.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
                column: "ImageUrls",
                value: "[\"https://example.com/products/coffee_table1.jpg\",\"https://example.com/products/coffee_table2.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
                column: "ImageUrls",
                value: "[\"https://example.com/products/dyson1.jpg\",\"https://example.com/products/dyson2.jpg\"]");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                column: "ImageUrls",
                value: "[\"https://example.com/products/jacket1.jpg\",\"https://example.com/products/jacket2.jpg\"]");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[] { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "SONY-002", null, "[\"https://example.com/products/sony1.jpg\",\"https://example.com/products/sony2.jpg\"]", "Sony WH-1000XM5 Headphones", 349.99m, 50, 4.5m, 100, 0 });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"), "Connectivity", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Bluetooth 5.2" },
                    { new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"), "Battery Life", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "30 hours" },
                    { new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"), "Noise Cancellation", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Yes" },
                    { new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"), "Type", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Over-ear" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"), "Touch-enabled", "Controls", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"), "High-resolution audio", "Sound", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"), "Soft ear cushions", "Comfort", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"), "Foldable design", "Portability", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") }
                });
        }
    }
}
