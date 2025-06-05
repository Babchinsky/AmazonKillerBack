using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class WishlistsSeedAndCartLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartLists",
                columns: new[] { "Id", "AddedAt", "Price", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { new Guid("229de273-0066-4a4a-8678-21eb61416578"), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.99m, new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), 1, new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef") },
                    { new Guid("85caea79-0bb1-4649-9102-142eb37c7664"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1199.99m, new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), 1, new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41") },
                    { new Guid("a2437747-dfe4-4d24-8cdf-5e44abbd2c7f"), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1199.99m, new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), 3, new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef") },
                    { new Guid("ab6454d8-69c2-4e81-8313-d2cdc0b1cf9c"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 349.99m, new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), 3, new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41") },
                    { new Guid("c51758a1-f536-463b-a921-cc9206a34927"), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.99m, new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), 2, new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76") }
                });

            migrationBuilder.InsertData(
                table: "WishlistItems",
                columns: new[] { "ProductId", "UserId", "AddedAt" },
                values: new object[,]
                {
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), new Guid("2583c105-264b-45ee-a535-3b939f4dd428"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("b116a743-b108-494a-abb5-a0c9673edbef"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartLists",
                keyColumn: "Id",
                keyValue: new Guid("229de273-0066-4a4a-8678-21eb61416578"));

            migrationBuilder.DeleteData(
                table: "CartLists",
                keyColumn: "Id",
                keyValue: new Guid("85caea79-0bb1-4649-9102-142eb37c7664"));

            migrationBuilder.DeleteData(
                table: "CartLists",
                keyColumn: "Id",
                keyValue: new Guid("a2437747-dfe4-4d24-8cdf-5e44abbd2c7f"));

            migrationBuilder.DeleteData(
                table: "CartLists",
                keyColumn: "Id",
                keyValue: new Guid("ab6454d8-69c2-4e81-8313-d2cdc0b1cf9c"));

            migrationBuilder.DeleteData(
                table: "CartLists",
                keyColumn: "Id",
                keyValue: new Guid("c51758a1-f536-463b-a921-cc9206a34927"));

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), new Guid("2583c105-264b-45ee-a535-3b939f4dd428") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("b116a743-b108-494a-abb5-a0c9673edbef") });

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41") });
        }
    }
}
