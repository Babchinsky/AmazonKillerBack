using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategorySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartLists",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "WishlistItems",
                keyColumns: new[] { "ProductId", "UserId" },
                keyValues: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IconName", "ImageUrl", "Name", "ParentId", "PropertyKeys", "Status" },
                values: new object[,]
                {
                    { new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "Furniture category", "furniture", "https://example.com/images/furniture.jpg", "Furniture", null, "[]", 0 },
                    { new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "Fashion category", "fashion", "https://example.com/images/fashion.jpg", "Fashion", null, "[]", 0 },
                    { new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "Electronics category", "electronics", "https://example.com/images/electronics.jpg", "Electronics", null, "[]", 0 },
                    { new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "Household category", "household", "https://example.com/images/household.jpg", "Household", null, "[]", 0 },
                    { new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "Work tools category", "work tools", "https://example.com/images/work_tools.jpg", "Work tools", null, "[]", 0 },
                    { new Guid("0e6feb3f-f795-4541-8cc6-7d7047951eb9"), "Kitchen Appliances category", "kitchen appliances", "https://example.com/images/kitchen_appliances.jpg", "Kitchen Appliances", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 },
                    { new Guid("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"), "Tool Storage category", "tool storage", "https://example.com/images/tool_storage.jpg", "Tool Storage", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"), "Safety Gear category", "safety gear", "https://example.com/images/safety_gear.jpg", "Safety Gear", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("1b6f5f96-233d-4b82-b30f-27643f6b62eb"), "Cleaning Supplies category", "cleaning supplies", "https://example.com/images/cleaning_supplies.jpg", "Cleaning Supplies", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 },
                    { new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"), "Power Tools category", "power tools", "https://example.com/images/power_tools.jpg", "Power Tools", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"), "Laptops category", "laptops", "https://example.com/images/laptops.jpg", "Laptops", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"), "Office Furniture category", "office furniture", "https://example.com/images/office_furniture.jpg", "Office Furniture", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"), "Bathroom category", "bathroom", "https://example.com/images/bathroom.jpg", "Bathroom", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 },
                    { new Guid("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"), "Accessories category", "accessories", "https://example.com/images/accessories.jpg", "Accessories", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"), "Living Room category", "living room", "https://example.com/images/living_room.jpg", "Living Room", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("69f22c76-7202-44e6-9132-09fd09c55632"), "Women's Clothing category", "women's clothing", "https://example.com/images/womens_clothing.jpg", "Women's Clothing", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "Men's Clothing category", "men's clothing", "https://example.com/images/mens_clothing.jpg", "Men's Clothing", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"), "Outdoor category", "outdoor", "https://example.com/images/outdoor.jpg", "Outdoor", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"), "Hand Tools category", "hand tools", "https://example.com/images/hand_tools.jpg", "Hand Tools", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"), "Cameras category", "cameras", "https://example.com/images/cameras.jpg", "Cameras", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"), "Shoes category", "shoes", "https://example.com/images/shoes.jpg", "Shoes", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "Audio Devices category", "audio devices", "https://example.com/images/audio_devices.jpg", "Audio Devices", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"), "Bedroom category", "bedroom", "https://example.com/images/bedroom.jpg", "Bedroom", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "Smartphones category", "smartphones", "https://example.com/images/smartphones.jpg", "Smartphones", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("d94af679-24f4-4ab2-ae1e-ba3689143579"), "Storage category", "storage", "https://example.com/images/storage.jpg", "Storage", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0e6feb3f-f795-4541-8cc6-7d7047951eb9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1b6f5f96-233d-4b82-b30f-27643f6b62eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69f22c76-7202-44e6-9132-09fd09c55632"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d94af679-24f4-4ab2-ae1e-ba3689143579"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8980e70c-3345-4885-8518-cfcda95b3078"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IconName", "ImageUrl", "Name", "ParentId", "PropertyKeys", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "A selection of books", "book", "https://example.com/images/books.jpg", "Books", null, "[]", 0 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Tech gadgets and accessories", "devices", "https://example.com/images/tech.jpg", "Tech", null, "[]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user@example.com", "Test", null, "User", "$2a$11$0123456789ABCDEFFEDCB.S2Yzr2tczlChVlvkY9yqWo1rec6s2eC", 0, 0 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@example.com", "Admin", null, "Root", "$2a$11$0123456789ABCDEFFEDCB.f3zF6Kwis6bGMA186omDrGf1JNLP/eK", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "InCartList", "InWishlist", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("11111111-1111-1111-1111-111111111111"), "01JS9QNDAYKK2CFRT5AKZF1YAA", null, "[]", true, true, "C# in Depth", 39.99m, 10, 5m, 0, 0 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("22222222-2222-2222-2222-222222222222"), "01JS9QNDAYKK2CFRT5AKZF1YBB", null, "[]", false, false, "Wireless Mouse", 19.99m, 50, 4m, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "CartLists",
                columns: new[] { "Id", "AddedAt", "Price", "ProductId", "Quantity", "UserId" },
                values: new object[] { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 39.99m, new Guid("55555555-5555-5555-5555-555555555555"), 1, new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Article", "CreatedAt", "ImageUrls", "Message", "ProductId", "Rating", "Tags", "UserId" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Great book!", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "[\"file1.jpg\",\"file2.jpg\"]", "Very useful for learning advanced C#", new Guid("55555555-5555-5555-5555-555555555555"), 5m, "[]", new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.InsertData(
                table: "WishlistItems",
                columns: new[] { "ProductId", "UserId", "AddedAt" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
