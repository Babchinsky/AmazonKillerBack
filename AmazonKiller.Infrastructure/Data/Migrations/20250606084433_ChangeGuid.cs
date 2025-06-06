using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("57f65602-00b0-4ca4-b5ac-4e1668392ada"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("677ab772-601e-4108-9d6e-41700b93b858"));

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
                keyValue: new Guid("efc6ca31-8560-4366-9806-c80af9c07c47"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("fb6080cb-56c6-4bd4-ac72-4ea8af86035b"));

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("184d5fd1-4e1d-42c2-9b58-d5d3c1b2235a"), "Fit", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Relaxed" },
                    { new Guid("3a57dbde-0659-4377-a618-5477c3f1c6ae"), "Length", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Midi" },
                    { new Guid("3b15cf2c-d0a6-45bb-a99f-2f0fa66cf91c"), "Chip", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "A17 Pro" },
                    { new Guid("3d768f6d-11d5-4033-8b6e-c2674d37b44a"), "Pattern", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Floral" },
                    { new Guid("44c10d0d-414c-4a75-baff-b5246a6e688b"), "Noise Cancellation", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "Adaptive" },
                    { new Guid("6c6b5864-33a0-4ec0-9a7e-34d73d226289"), "Chuck Size", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "13mm" },
                    { new Guid("6fa61d21-700f-4c0e-a04f-c1a1a8a2745b"), "Battery Life", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "24 hours" },
                    { new Guid("75c1376d-1ae0-405f-a46d-15c805e3e212"), "Charging", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "USB-C Fast Charging" },
                    { new Guid("7aa17ee1-6b46-4d41-8ae2-4f2f2931e0aa"), "Finish", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "White" },
                    { new Guid("83cfd9cb-24a9-4056-bb90-85986b3b6310"), "Storage", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "256GB" },
                    { new Guid("a49880a3-4ba6-4bb0-8015-4bc83b6dbbcd"), "Camera", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "48MP Triple-lens" },
                    { new Guid("aa64df41-c001-4d1a-91b7-0807f2b5c0de"), "Type", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "Over-ear" },
                    { new Guid("b5bdf51b-e460-4e8a-8c44-22625f91ae45"), "Display", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "6.7-inch OLED" },
                    { new Guid("b8bc8f7a-267f-43a8-b81e-360d250209c3"), "Speed", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "0–2000 RPM" },
                    { new Guid("c1f7efb2-8dbb-4d6e-890b-91873cc0f8a2"), "Material", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Viscose" },
                    { new Guid("c8d6d4e7-3c25-41f4-9c3c-144143d3cb94"), "Material", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "Particleboard" },
                    { new Guid("e0701d10-c221-4032-b3a5-4a05c69f56c5"), "Weight", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "5.8kg" },
                    { new Guid("ec9f4ff8-dc66-4a6a-a88d-dfd03275e05a"), "Dimensions", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "90x55 cm" },
                    { new Guid("f31206e4-8237-4db1-b3a0-544b26dd5865"), "Voltage", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "20V" },
                    { new Guid("f5035e59-f0f6-4db6-8160-0df17931a1c8"), "Battery", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "2x 5.0Ah Li-ion" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("06695e1f-8d42-498c-8d34-e3281d49753b"), "Cinematic mode & Night photography", "Camera System", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("146e8860-5f1a-4086-85a1-bcbe5e16a982"), "Tool-free assembly", "Assembly", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("1c6c2255-9535-4520-84ee-b00db4a2225d"), "Ergonomic handle", "Grip", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("1e4cc7b4-51a5-4bfb-8e36-1ce9a2a6c8b0"), "Brushless motor", "Performance", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("2a222bb7-cc32-4e2f-9ad3-2ad2aaf1fc6f"), "Heavy-duty construction", "Durability", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("2e5c6e3a-bb5f-42f7-b933-0e21dcdb267f"), "Plush cushioning", "Comfort", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("431d02bb-1446-4d9a-8f71-207b6d0ffbe1"), "Simple and modern", "Design", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("56e75d3f-9fb5-4d8c-a986-8985a8aa96c1"), "Titanium frame", "Build Quality", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("6ab182fd-45bb-4747-93d7-4533cdd9f88c"), "LED work light", "Convenience", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("76bdc733-91d3-48f1-a447-b78e0e4b9991"), "Smooth iOS experience", "Performance", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("781153a3-0555-49ae-987e-09dbde5172ee"), "Suitable for casual and formal", "Versatility", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("93c3210e-48e6-4fc4-8783-47bdc8601694"), "Touch & voice control", "Controls", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("a3a37d1e-26e9-40f0-b935-1e5e43b83e02"), "Budget-friendly option", "Affordability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("a5fd738e-6d61-49f7-b51c-dcdbbcd27644"), "Breathable fabric", "Comfort", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("a90fa301-e8e3-4097-a507-cdc1a9f5b008"), "Lightweight design", "Portability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("b9b205bb-9a76-4456-a0cb-dc28e4fce1c5"), "Elegant and breezy", "Style", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("da2c2ff2-1c38-4a23-a8cc-25b4f4ec2680"), "Modern aesthetic", "Design", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("e4c01f56-8e2e-4866-a98f-6c4f69f63f6f"), "Up to 29 hours video playback", "Battery Life", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("f00725dc-2d23-4ff3-93b6-bcb9fdf8f293"), "CustomTune technology", "Sound Quality", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("fbf426f5-78e4-4d4f-b183-3fcf3870e04b"), "Machine washable", "Care", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("184d5fd1-4e1d-42c2-9b58-d5d3c1b2235a"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("3a57dbde-0659-4377-a618-5477c3f1c6ae"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("3b15cf2c-d0a6-45bb-a99f-2f0fa66cf91c"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("3d768f6d-11d5-4033-8b6e-c2674d37b44a"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("44c10d0d-414c-4a75-baff-b5246a6e688b"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("6c6b5864-33a0-4ec0-9a7e-34d73d226289"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("6fa61d21-700f-4c0e-a04f-c1a1a8a2745b"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("75c1376d-1ae0-405f-a46d-15c805e3e212"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("7aa17ee1-6b46-4d41-8ae2-4f2f2931e0aa"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("83cfd9cb-24a9-4056-bb90-85986b3b6310"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("a49880a3-4ba6-4bb0-8015-4bc83b6dbbcd"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("aa64df41-c001-4d1a-91b7-0807f2b5c0de"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("b5bdf51b-e460-4e8a-8c44-22625f91ae45"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("b8bc8f7a-267f-43a8-b81e-360d250209c3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c1f7efb2-8dbb-4d6e-890b-91873cc0f8a2"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c8d6d4e7-3c25-41f4-9c3c-144143d3cb94"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("e0701d10-c221-4032-b3a5-4a05c69f56c5"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ec9f4ff8-dc66-4a6a-a88d-dfd03275e05a"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("f31206e4-8237-4db1-b3a0-544b26dd5865"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("f5035e59-f0f6-4db6-8160-0df17931a1c8"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("06695e1f-8d42-498c-8d34-e3281d49753b"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("146e8860-5f1a-4086-85a1-bcbe5e16a982"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1c6c2255-9535-4520-84ee-b00db4a2225d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1e4cc7b4-51a5-4bfb-8e36-1ce9a2a6c8b0"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("2a222bb7-cc32-4e2f-9ad3-2ad2aaf1fc6f"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("2e5c6e3a-bb5f-42f7-b933-0e21dcdb267f"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("431d02bb-1446-4d9a-8f71-207b6d0ffbe1"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("56e75d3f-9fb5-4d8c-a986-8985a8aa96c1"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("6ab182fd-45bb-4747-93d7-4533cdd9f88c"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("76bdc733-91d3-48f1-a447-b78e0e4b9991"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("781153a3-0555-49ae-987e-09dbde5172ee"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("93c3210e-48e6-4fc4-8783-47bdc8601694"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("a3a37d1e-26e9-40f0-b935-1e5e43b83e02"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("a5fd738e-6d61-49f7-b51c-dcdbbcd27644"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("a90fa301-e8e3-4097-a507-cdc1a9f5b008"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b9b205bb-9a76-4456-a0cb-dc28e4fce1c5"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("da2c2ff2-1c38-4a23-a8cc-25b4f4ec2680"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("e4c01f56-8e2e-4866-a98f-6c4f69f63f6f"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("f00725dc-2d23-4ff3-93b6-bcb9fdf8f293"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("fbf426f5-78e4-4d4f-b183-3fcf3870e04b"));

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
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
                    { new Guid("9253fc3f-01a3-4572-808a-54b7fa5cb90d"), "Material", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "Particleboard" },
                    { new Guid("a9397426-5bcd-4d16-995b-cb0730a006c4"), "Battery Life", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "24 hours" },
                    { new Guid("ac55aa2f-5a9e-49d3-90d4-b9cc39dbb113"), "Storage", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "256GB" },
                    { new Guid("c1c19ee4-1054-4e1b-9e83-5c8742b91ab7"), "Length", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Midi" },
                    { new Guid("e0591b47-4c6f-483a-84e0-66dede21a43a"), "Camera", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "48MP Triple-lens" },
                    { new Guid("e2bc5a0f-802d-4635-9064-6a19d6acda7c"), "Battery", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "2x 5.0Ah Li-ion" },
                    { new Guid("e5e1051a-7744-44aa-abf8-dcf0473da129"), "Material", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Viscose" },
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
                    { new Guid("57f65602-00b0-4ca4-b5ac-4e1668392ada"), "Ergonomic handle", "Grip", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("677ab772-601e-4108-9d6e-41700b93b858"), "Simple and modern", "Design", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("82d1193a-84fc-4ce4-95bf-05b5c874b9dc"), "Plush cushioning", "Comfort", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("9af9930f-c737-4035-a32f-79203065b1a3"), "CustomTune technology", "Sound Quality", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("9be195d5-9b77-4977-b773-e9bd9759bd46"), "LED work light", "Convenience", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("a049cef8-7e94-486b-a739-999907cadb1b"), "Up to 29 hours video playback", "Battery Life", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("b2d9d0d1-e8a5-4b66-a584-14bd1ea5727d"), "Titanium frame", "Build Quality", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("b322b578-aa89-4394-8648-15c08b3e14fc"), "Budget-friendly option", "Affordability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("bc8514b8-b984-4d91-b4c5-02a028bad838"), "Modern aesthetic", "Design", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("bd8b7454-96a9-4384-ad40-1e37e0541e6d"), "Cinematic mode & Night photography", "Camera System", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("c6e62883-f371-4734-bf52-f4be01266722"), "Tool-free assembly", "Assembly", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("db7d1a0d-cb6a-443c-8502-159f7a150c5a"), "Heavy-duty construction", "Durability", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("e7e4aa23-11f6-4067-8259-af5f285aa95c"), "Lightweight design", "Portability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("efc6ca31-8560-4366-9806-c80af9c07c47"), "Machine washable", "Care", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("fb6080cb-56c6-4bd4-ac72-4ea8af86035b"), "Touch & voice control", "Controls", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") }
                });
        }
    }
}
