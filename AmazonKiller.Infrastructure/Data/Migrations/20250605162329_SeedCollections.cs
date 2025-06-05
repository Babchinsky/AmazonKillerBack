using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "IsActive", "MaxPrice", "MinPrice", "Title" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "https://example.com/collections/galaxy.jpg", true, 1300m, 1000m, "Galaxy Highlights" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "https://example.com/collections/sony.jpg", true, 400m, 300m, "Sony Audio Bestsellers" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "https://example.com/collections/denim.jpg", true, 100m, 50m, "Denim Essentials" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "https://example.com/collections/tables.jpg", true, 160m, 120m, "Modern Coffee Tables" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "https://example.com/collections/makita.jpg", true, 250m, 200m, "Makita Power Tools" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFilters",
                columns: new[] { "CollectionId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Battery", "5000mAh" },
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Camera", "200MP" },
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Storage", "256GB" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Noise Cancellation", "Yes" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Type", "Over-ear" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Fit", "Regular" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Material", "100% Cotton" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Finish", "Natural varnish" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Material", "Oak wood" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Battery", "2 x 5.0Ah Li-ion" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Voltage", "18V" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), "Battery", "5000mAh" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), "Camera", "200MP" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), "Storage", "256GB" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000002"), "Noise Cancellation", "Yes" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000002"), "Type", "Over-ear" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), "Fit", "Regular" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), "Material", "100% Cotton" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000004"), "Finish", "Natural varnish" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000004"), "Material", "Oak wood" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000005"), "Battery", "2 x 5.0Ah Li-ion" });

            migrationBuilder.DeleteData(
                table: "CollectionFilters",
                keyColumns: new[] { "CollectionId", "Key", "Value" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000005"), "Voltage", "18V" });

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));
        }
    }
}
