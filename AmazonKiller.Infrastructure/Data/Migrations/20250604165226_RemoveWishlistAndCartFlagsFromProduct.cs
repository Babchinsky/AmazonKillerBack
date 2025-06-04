using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWishlistAndCartFlagsFromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InCartList",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InWishlist",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
                column: "ImageUrl",
                value: "https://example.com/images/worktools.jpg");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "SAM-001", null, "[\"https://example.com/products/samsung1.jpg\",\"https://example.com/products/samsung2.jpg\"]", "Samsung Galaxy S23 Ultra", 1199.99m, 50, 4.5m, 100, 0 },
                    { new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "WTL-001", null, "[\"https://example.com/products/makita1.jpg\",\"https://example.com/products/makita2.jpg\"]", "Makita Cordless Hammer Drill", 229.99m, 50, 4.5m, 100, 0 },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "FUR-001", null, "[\"https://example.com/products/coffee_table1.jpg\",\"https://example.com/products/coffee_table2.jpg\"]", "Modern Wooden Coffee Table", 149.99m, 50, 4.5m, 100, 0 },
                    { new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "HOU-001", null, "[\"https://example.com/products/dyson1.jpg\",\"https://example.com/products/dyson2.jpg\"]", "Dyson V15 Detect Vacuum Cleaner", 699.0m, 50, 4.5m, 100, 0 },
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "SONY-002", null, "[\"https://example.com/products/sony1.jpg\",\"https://example.com/products/sony2.jpg\"]", "Sony WH-1000XM5 Headphones", 349.99m, 50, 4.5m, 100, 0 },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "FAS-001", null, "[\"https://example.com/products/jacket1.jpg\",\"https://example.com/products/jacket2.jpg\"]", "Men's Denim Jacket", 69.99m, 50, 4.5m, 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("07d62dcb-0736-4687-b066-92c3cde5fa9d"), "Battery", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "2 x 5.0Ah Li-ion" },
                    { new Guid("163febea-12c5-4ba7-af3e-5b3d5fa01e4f"), "Weight", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "18kg" },
                    { new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"), "Connectivity", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Bluetooth 5.2" },
                    { new Guid("2d3c46bc-1bd0-45c0-a695-6b3ea0cea55d"), "Camera", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "200MP" },
                    { new Guid("31ed2059-8d7c-440e-849c-92b82fa07535"), "Display", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "6.8-inch AMOLED" },
                    { new Guid("34b80662-4ddf-44df-aeab-0a131d4ca441"), "Fit", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "Regular" },
                    { new Guid("45890b2d-4656-4bf5-bea8-8d68cef13afa"), "Storage", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "256GB" },
                    { new Guid("4946c132-8ec4-41ce-891d-4788067a4a66"), "Finish", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "Natural varnish" },
                    { new Guid("50c7325d-5a50-4494-8356-c4ae304e70f5"), "Dimensions", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "120x60x45 cm" },
                    { new Guid("5a29ac69-487d-4609-b29e-3b6f30b088ce"), "Type", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "Cordless" },
                    { new Guid("5d1af968-e023-4bf1-a58b-4d6701785946"), "Battery", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "5000mAh" },
                    { new Guid("7ba0bf0e-ed40-4e27-a0ac-85dd45279867"), "Battery Life", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "60 minutes" },
                    { new Guid("7c252a25-5c76-4e8b-be65-22e8651667ed"), "Dustbin Capacity", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "0.76L" },
                    { new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"), "Battery Life", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "30 hours" },
                    { new Guid("90bba9ca-cc95-405e-8a8e-da471eafcde2"), "Chuck Size", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "13mm" },
                    { new Guid("93731c22-16a2-4c9e-b4d8-3aa7485d5acb"), "Color", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "Blue" },
                    { new Guid("a6a26067-18e9-4543-8828-8069f09a411f"), "Material", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "Oak wood" },
                    { new Guid("ac51bf93-88a8-4b39-b106-b8a7f5c4db92"), "Season", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "All seasons" },
                    { new Guid("b559db54-4289-499f-88dc-35a4c9978e4c"), "Power", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "230AW" },
                    { new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"), "Noise Cancellation", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Yes" },
                    { new Guid("e0e1e5c9-55d8-4d16-bca2-e45a0d3553cc"), "Voltage", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "18V" },
                    { new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"), "Type", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Over-ear" },
                    { new Guid("f46c7e06-8dfe-48e9-b47e-9953e159ae69"), "Speed", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "0-2000 RPM" },
                    { new Guid("f75be0e7-0d41-45e8-87d7-e53060c87cd4"), "Material", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "100% Cotton" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("015d3ed7-c231-405e-bbd2-ef99c8171603"), "Premium glass and metal", "Build", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("1822758b-de5a-4f53-aea5-c624d90add9b"), "Intelligent optimization", "Efficiency", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("1e8754f1-993e-4586-b0df-d16475bcd262"), "All-day usage", "Battery Life", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("35198d10-7fbf-4919-aa3f-527c7e76abcb"), "Sleek and minimal", "Design", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("38c8f67f-7b05-4f06-8856-546a4e499d5c"), "Made to last", "Durability", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("49b29ac4-ed20-4592-8690-304aa1e80df3"), "High torque for tough jobs", "Performance", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"), "Touch-enabled", "Controls", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("6334b668-3933-4abb-8d5d-4324bb4ed08a"), "Solid wood construction", "Durability", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("75e0cc52-9a6b-4157-b453-57f390790cf4"), "Laser detects microscopic dust", "Performance", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"), "High-resolution audio", "Sound", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("7aeefca5-b681-41cf-baef-0ab5306f250a"), "Machine washable", "Care", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("7c49174a-ea92-4119-b3bb-2951ffbaba67"), "Multiple attachments included", "Tools", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("8166c8f2-21fd-439c-ad3f-1eabe29bc76f"), "Ergonomic grip", "Comfort", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("905cdea9-9662-4f42-82d4-c0b24e957ee8"), "Pairs with any outfit", "Versatility", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("9b6befa0-ebf3-4701-a70c-a8bb3c8689a1"), "Whole-machine HEPA filtration", "Filter", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("9f7ba4ac-9b83-41bc-9fc9-53896c0fcd17"), "Pro-grade camera system", "Camera Quality", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("a3c061b9-91f9-4d01-be37-4eb05da33ac5"), "Metal gear housing", "Durability", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"), "Soft ear cushions", "Comfort", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("b6e56093-2fc5-473d-818a-26a9e5b52f82"), "Easy to wipe clean", "Maintenance", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("c4c5a991-e2cd-4d1b-a176-036f70667cb7"), "For dark areas", "LED Light", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("c6676eab-a776-4380-9b0e-a07b10da8236"), "Snapdragon 8 Gen 2", "Performance", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"), "Foldable design", "Portability", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("f4eb7825-2ffd-4d1f-a9ba-5635ea698534"), "Quick setup included", "Assembly", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("f7f4c40c-82d3-488f-bf1a-9094dc2048b0"), "Casual yet rugged", "Style", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("07d62dcb-0736-4687-b066-92c3cde5fa9d"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("163febea-12c5-4ba7-af3e-5b3d5fa01e4f"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("2d3c46bc-1bd0-45c0-a695-6b3ea0cea55d"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("31ed2059-8d7c-440e-849c-92b82fa07535"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("34b80662-4ddf-44df-aeab-0a131d4ca441"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("45890b2d-4656-4bf5-bea8-8d68cef13afa"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("4946c132-8ec4-41ce-891d-4788067a4a66"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("50c7325d-5a50-4494-8356-c4ae304e70f5"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("5a29ac69-487d-4609-b29e-3b6f30b088ce"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("5d1af968-e023-4bf1-a58b-4d6701785946"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("7ba0bf0e-ed40-4e27-a0ac-85dd45279867"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("7c252a25-5c76-4e8b-be65-22e8651667ed"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("90bba9ca-cc95-405e-8a8e-da471eafcde2"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("93731c22-16a2-4c9e-b4d8-3aa7485d5acb"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("a6a26067-18e9-4543-8828-8069f09a411f"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ac51bf93-88a8-4b39-b106-b8a7f5c4db92"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("b559db54-4289-499f-88dc-35a4c9978e4c"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("e0e1e5c9-55d8-4d16-bca2-e45a0d3553cc"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("f46c7e06-8dfe-48e9-b47e-9953e159ae69"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("f75be0e7-0d41-45e8-87d7-e53060c87cd4"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("015d3ed7-c231-405e-bbd2-ef99c8171603"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1822758b-de5a-4f53-aea5-c624d90add9b"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1e8754f1-993e-4586-b0df-d16475bcd262"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("35198d10-7fbf-4919-aa3f-527c7e76abcb"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("38c8f67f-7b05-4f06-8856-546a4e499d5c"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("49b29ac4-ed20-4592-8690-304aa1e80df3"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("6334b668-3933-4abb-8d5d-4324bb4ed08a"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("75e0cc52-9a6b-4157-b453-57f390790cf4"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("7aeefca5-b681-41cf-baef-0ab5306f250a"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("7c49174a-ea92-4119-b3bb-2951ffbaba67"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("8166c8f2-21fd-439c-ad3f-1eabe29bc76f"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("905cdea9-9662-4f42-82d4-c0b24e957ee8"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("9b6befa0-ebf3-4701-a70c-a8bb3c8689a1"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("9f7ba4ac-9b83-41bc-9fc9-53896c0fcd17"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("a3c061b9-91f9-4d01-be37-4eb05da33ac5"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b6e56093-2fc5-473d-818a-26a9e5b52f82"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("c4c5a991-e2cd-4d1b-a176-036f70667cb7"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("c6676eab-a776-4380-9b0e-a07b10da8236"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("f4eb7825-2ffd-4d1f-a9ba-5635ea698534"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("f7f4c40c-82d3-488f-bf1a-9094dc2048b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a055168e-3130-4b0a-8495-60e25d62e057"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"));

            migrationBuilder.AddColumn<bool>(
                name: "InCartList",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InWishlist",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
                column: "ImageUrl",
                value: "https://example.com/images/work_tools.jpg");
        }
    }
}
