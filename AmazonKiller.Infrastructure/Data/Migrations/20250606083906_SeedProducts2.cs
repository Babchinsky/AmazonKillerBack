using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"),
                column: "PropertyKeys",
                value: "[\"Voltage\",\"Speed\",\"Battery\",\"Chuck Size\"]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"),
                column: "PropertyKeys",
                value: "[\"Material\",\"Dimensions\",\"Weight\",\"Finish\"]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69f22c76-7202-44e6-9132-09fd09c55632"),
                column: "PropertyKeys",
                value: "[\"Material\",\"Fit\",\"Length\",\"Pattern\"]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                column: "PropertyKeys",
                value: "[\"Type\",\"Noise Cancellation\",\"Battery Life\",\"Connectivity\",\"Charging\"]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
                column: "PropertyKeys",
                value: "[\"Display\",\"Battery\",\"Camera\",\"Storage\",\"Chip\"]");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "BOSE-001", null, "[\"https://content2.rozetka.com.ua/goods/images/big/382915623.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/382915624.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/382915625.jpg\",\"https://content.rozetka.com.ua/goods/images/big/382915629.jpg\"]", "Bose QuietComfort Ultra", 379.99m, 35, 4.6m, 150, 0 },
                    { new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"), "WTL-002", null, "[\"https://content2.rozetka.com.ua/goods/images/big/11956995.jpg\"]", "DeWalt DCD996 Cordless Drill", 199.99m, 60, 4.8m, 180, 0 },
                    { new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), new Guid("69f22c76-7202-44e6-9132-09fd09c55632"), "FAS-002", null, "[\"https://static.zara.net/assets/public/5383/1e3a/567f4efa9ab2/540875121096/04772368808-p/04772368808-p.jpg?ts=1747906901087\\u0026w=750\",\"https://static.zara.net/assets/public/1739/0738/387f4ed59035/81ddaea8d349/04772368808-a2/04772368808-a2.jpg?ts=1747906905715\\u0026w=750\",\"https://static.zara.net/assets/public/6eda/d9b8/33b748b0941d/85074a50ec93/04772368808-a4/04772368808-a4.jpg?ts=1747906897381\\u0026w=563\"]", "Zara Floral Midi Dress", 89.99m, 70, 4.4m, 90, 0 },
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "SONY-002", null, "[\"https://content2.rozetka.com.ua/goods/images/big/296707484.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/296707485.jpg\"]", "Sony WH-1000XM5 Headphones", 349.99m, 50, 4.5m, 100, 0 },
                    { new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"), "FUR-002", null, "[\"https://home-club.com.ua//images/thumbs/0018524_-_510.jpeg\",\"https://home-club.com.ua//images/thumbs/0310065_-.jpeg\",\"https://home-club.com.ua//images/thumbs/0043920_-.jpeg\"]", "IKEA LACK Coffee Table", 39.99m, 80, 4.2m, 320, 0 },
                    { new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "APP-002", null, "[\"https://content2.rozetka.com.ua/goods/images/big/524114081.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/524114107.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/524114117.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/524114126.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/524114144.jpg\"]", "Apple iPhone 15 Pro Max", 1399.99m, 40, 4.7m, 200, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"), "Connectivity", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Bluetooth 5.2" },
                    { new Guid("24140ea9-3afc-45f3-9926-4b788090b90a"), "Type", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "Over-ear" },
                    { new Guid("2552d091-b390-4ca4-98fa-ea7c09b0f5e5"), "Pattern", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Floral" },
                    { new Guid("384364bc-0d47-4358-b460-aeceb2b19fff"), "Chuck Size", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "13mm" },
                    { new Guid("397b100d-08b5-45bb-a22b-7352870a7d59"), "Finish", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "White" },
                    { new Guid("4ddde602-f6fa-4afb-931f-d7bd9bb319bd"), "Speed", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "0–2000 RPM" },
                    { new Guid("51cd277c-5dba-433d-bbc8-8b49850db8b3"), "Chip", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "A17 Pro" },
                    { new Guid("575e436d-e69f-4b2a-9714-0f20b47a7ec6"), "Voltage", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "20V" },
                    { new Guid("59590748-150e-4db0-855f-3254b7e2ce59"), "Display", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "6.7-inch OLED" },
                    { new Guid("6501465b-7fe8-4337-afd8-27d56747c76c"), "Dimensions", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "90x55 cm" },
                    { new Guid("685e38a5-46a4-4438-a0ac-1a4ebe588959"), "Fit", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Relaxed" },
                    { new Guid("69d8711e-b99f-4d8b-84a3-d8eddef1d717"), "Noise Cancellation", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "Adaptive" },
                    { new Guid("6f35c506-1a9e-435a-8c4e-c2a2933d3fea"), "Weight", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "5.8kg" },
                    { new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"), "Battery Life", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "30 hours" },
                    { new Guid("9253fc3f-01a3-4572-808a-54b7fa5cb90d"), "Material", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "Particleboard" },
                    { new Guid("a9397426-5bcd-4d16-995b-cb0730a006c4"), "Battery Life", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "24 hours" },
                    { new Guid("ac55aa2f-5a9e-49d3-90d4-b9cc39dbb113"), "Storage", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "256GB" },
                    { new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"), "Noise Cancellation", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Yes" },
                    { new Guid("c1c19ee4-1054-4e1b-9e83-5c8742b91ab7"), "Length", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Midi" },
                    { new Guid("e0591b47-4c6f-483a-84e0-66dede21a43a"), "Camera", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "48MP Triple-lens" },
                    { new Guid("e2bc5a0f-802d-4635-9064-6a19d6acda7c"), "Battery", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "2x 5.0Ah Li-ion" },
                    { new Guid("e5e1051a-7744-44aa-abf8-dcf0473da129"), "Material", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Viscose" },
                    { new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"), "Type", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Over-ear" },
                    { new Guid("ff4f11ce-10b0-4a8c-9963-b8ad59e643e3"), "Charging", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "USB-C Fast Charging" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0e1b63c3-3162-45bc-aaa7-34c58ab9c0cd"), "Suitable for casual and formal", "Versatility", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("1149dfd7-62c5-4131-8572-135fa14fe970"), "Brushless motor", "Performance", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("1d8c97b1-88c0-4013-bd1d-11fba10faaa1"), "Breathable fabric", "Comfort", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("2d0107d4-ed41-4995-90ca-a783531a11f8"), "Smooth iOS experience", "Performance", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("3e061afa-c287-4677-a6f6-5714e0b7301a"), "Elegant and breezy", "Style", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"), "Touch-enabled", "Controls", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("57f65602-00b0-4ca4-b5ac-4e1668392ada"), "Ergonomic handle", "Grip", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("677ab772-601e-4108-9d6e-41700b93b858"), "Simple and modern", "Design", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"), "High-resolution audio", "Sound", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("82d1193a-84fc-4ce4-95bf-05b5c874b9dc"), "Plush cushioning", "Comfort", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("9af9930f-c737-4035-a32f-79203065b1a3"), "CustomTune technology", "Sound Quality", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("9be195d5-9b77-4977-b773-e9bd9759bd46"), "LED work light", "Convenience", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("a049cef8-7e94-486b-a739-999907cadb1b"), "Up to 29 hours video playback", "Battery Life", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("b2d9d0d1-e8a5-4b66-a584-14bd1ea5727d"), "Titanium frame", "Build Quality", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("b322b578-aa89-4394-8648-15c08b3e14fc"), "Budget-friendly option", "Affordability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"), "Soft ear cushions", "Comfort", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("bc8514b8-b984-4d91-b4c5-02a028bad838"), "Modern aesthetic", "Design", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("bd8b7454-96a9-4384-ad40-1e37e0541e6d"), "Cinematic mode & Night photography", "Camera System", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("c6e62883-f371-4734-bf52-f4be01266722"), "Tool-free assembly", "Assembly", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("db7d1a0d-cb6a-443c-8502-159f7a150c5a"), "Heavy-duty construction", "Durability", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("e7e4aa23-11f6-4067-8259-af5f285aa95c"), "Lightweight design", "Portability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"), "Foldable design", "Portability", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("efc6ca31-8560-4366-9806-c80af9c07c47"), "Machine washable", "Care", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("fb6080cb-56c6-4bd4-ac72-4ea8af86035b"), "Touch & voice control", "Controls", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("24140ea9-3afc-45f3-9926-4b788090b90a"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("2552d091-b390-4ca4-98fa-ea7c09b0f5e5"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("384364bc-0d47-4358-b460-aeceb2b19fff"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("397b100d-08b5-45bb-a22b-7352870a7d59"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("4ddde602-f6fa-4afb-931f-d7bd9bb319bd"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("51cd277c-5dba-433d-bbc8-8b49850db8b3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("575e436d-e69f-4b2a-9714-0f20b47a7ec6"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("59590748-150e-4db0-855f-3254b7e2ce59"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("6501465b-7fe8-4337-afd8-27d56747c76c"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("685e38a5-46a4-4438-a0ac-1a4ebe588959"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("69d8711e-b99f-4d8b-84a3-d8eddef1d717"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("6f35c506-1a9e-435a-8c4e-c2a2933d3fea"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("9253fc3f-01a3-4572-808a-54b7fa5cb90d"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("a9397426-5bcd-4d16-995b-cb0730a006c4"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ac55aa2f-5a9e-49d3-90d4-b9cc39dbb113"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c1c19ee4-1054-4e1b-9e83-5c8742b91ab7"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("e0591b47-4c6f-483a-84e0-66dede21a43a"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("e2bc5a0f-802d-4635-9064-6a19d6acda7c"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("e5e1051a-7744-44aa-abf8-dcf0473da129"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ff4f11ce-10b0-4a8c-9963-b8ad59e643e3"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("0e1b63c3-3162-45bc-aaa7-34c58ab9c0cd"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1149dfd7-62c5-4131-8572-135fa14fe970"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1d8c97b1-88c0-4013-bd1d-11fba10faaa1"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("2d0107d4-ed41-4995-90ca-a783531a11f8"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("3e061afa-c287-4677-a6f6-5714e0b7301a"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("57f65602-00b0-4ca4-b5ac-4e1668392ada"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("677ab772-601e-4108-9d6e-41700b93b858"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("82d1193a-84fc-4ce4-95bf-05b5c874b9dc"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("9af9930f-c737-4035-a32f-79203065b1a3"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("9be195d5-9b77-4977-b773-e9bd9759bd46"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("a049cef8-7e94-486b-a739-999907cadb1b"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b2d9d0d1-e8a5-4b66-a584-14bd1ea5727d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b322b578-aa89-4394-8648-15c08b3e14fc"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("bc8514b8-b984-4d91-b4c5-02a028bad838"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("bd8b7454-96a9-4384-ad40-1e37e0541e6d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("c6e62883-f371-4734-bf52-f4be01266722"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("db7d1a0d-cb6a-443c-8502-159f7a150c5a"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("e7e4aa23-11f6-4067-8259-af5f285aa95c"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("efc6ca31-8560-4366-9806-c80af9c07c47"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("fb6080cb-56c6-4bd4-ac72-4ea8af86035b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"),
                column: "PropertyKeys",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"),
                column: "PropertyKeys",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69f22c76-7202-44e6-9132-09fd09c55632"),
                column: "PropertyKeys",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                column: "PropertyKeys",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
                column: "PropertyKeys",
                value: "[\"Display\",\"Battery\",\"Camera\",\"Storage\"]");
        }
    }
}
