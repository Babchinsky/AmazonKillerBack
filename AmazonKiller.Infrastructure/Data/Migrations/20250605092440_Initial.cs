using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyKeys = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    SoldCount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    ReviewsCount = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_Delivery_FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info_Delivery_LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info_Delivery_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Info_Delivery_Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info_Delivery_Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info_Delivery_Address_State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Info_Delivery_Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Info_Delivery_Address_HouseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Info_Delivery_Address_ApartmentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Info_Delivery_Address_PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Info_Delivery_Address_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info_Payment_PaymentType = table.Column<int>(type: "int", nullable: false),
                    Info_Payment_CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Payment_ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Payment_Cvv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Info_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionFilters",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionFilters", x => new { x.CollectionId, x.Key, x.Value });
                    table.ForeignKey(
                        name: "FK_CollectionFilters_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartLists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItems", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_WishlistItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.CheckConstraint("CK_OrderItem_Quantity_Positive", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewLikes",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewLikes", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_ReviewLikes_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IconName", "ImageUrl", "Name", "ParentId", "PropertyKeys", "Status" },
                values: new object[,]
                {
                    { new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "Furniture category", "furniture", "https://example.com/images/furniture.jpg", "Furniture", null, "[\"Material\",\"Dimensions\",\"Weight\",\"Finish\"]", 0 },
                    { new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "Fashion category", "fashion", "https://example.com/images/fashion.jpg", "Fashion", null, "[]", 0 },
                    { new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "Electronics category", "electronics", "https://example.com/images/electronics.jpg", "Electronics", null, "[]", 0 },
                    { new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "Household category", "household", "https://example.com/images/household.jpg", "Household", null, "[\"Type\",\"Battery Life\",\"Dustbin Capacity\",\"Power\"]", 0 },
                    { new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "Work tools category", "work tools", "https://example.com/images/worktools.jpg", "Work tools", null, "[\"Voltage\",\"Chuck Size\",\"Speed\",\"Battery\"]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"), "hallshaun8@example.com", "Charles", null, "Cook", "$2b$12$B./Bh7QhdcmttuAWXIt8dOp5Hul0w7YjOCMBCnGUfHQV4NvKfQ8Xe", 0, 0 },
                    { new Guid("2583c105-264b-45ee-a535-3b939f4dd428"), "suzannegonzalez5@example.com", "Jennifer", null, "Delacruz", "$2b$12$bUoOhVkj0HkDTCZlh8/n9O2m7s7.FwtwsJYj4fiR4OnZN2cKl9S9K", 0, 0 },
                    { new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"), "eric737@example.com", "John", null, "Hernandez", "$2b$12$hZMooIIRDBrx/2SZ9FbS9uuT/M4esP1.z1UFFvLHfKrcLYLccRTz6", 0, 0 },
                    { new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"), "kimberly906@example.com", "Daniel", null, "Kaiser", "$2b$12$zhpKLnHJl9jZxDcwwGhbyO8yDViIlu0E.WrbucVxYqfSvZxJqIMzm", 0, 0 },
                    { new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"), "michaelterrell1@example.com", "Kathy", null, "Thomas", "$2b$12$JthvV5eK9b0BX972kty2PuNuUd4Nk3wGLklIlj0HX2wInNS/78H7u", 0, 0 },
                    { new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"), "mjones3@example.com", "Samantha", null, "Moore", "$2b$12$XL/cSsxTSvYunP0ws3PTfOowebceqDPLauAE1qJcpljQwPgXXvTIG", 0, 0 },
                    { new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"), "cannonkelly9@example.com", "Christopher", null, "Salazar", "$2b$12$r9HYkq1hv0wiwZh05W6fq.6b3qoZxXrOfr/xrFSA//x69Qu77mOJO", 0, 0 },
                    { new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"), "nparrish10@example.com", "Jason", null, "Meza", "$2b$12$ix2jyWO01HHxwhtmLFIFXO/JbQ8eqT.IaJw5xrGAgcXbN/HL7ZIZO", 0, 0 },
                    { new Guid("b116a743-b108-494a-abb5-a0c9673edbef"), "heather934@example.com", "Brittany", null, "Edwards", "$2b$12$KPKg2yfoi0KQriKvrpKtYe3lGI67jJMkfncwg79HN1K0ln/PQwkym", 0, 0 },
                    { new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"), "april992@example.com", "Amanda", null, "Decker", "$2b$12$smw9z353sKgENxXVnQs6g.1EHa6UYkFh9jpq/ILRjrzDzY5lS9Nxa", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IconName", "ImageUrl", "Name", "ParentId", "PropertyKeys", "Status" },
                values: new object[,]
                {
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
                    { new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "Men's Clothing category", "men's clothing", "https://example.com/images/mens_clothing.jpg", "Men's Clothing", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[\"Material\",\"Fit\",\"Color\",\"Season\"]", 0 },
                    { new Guid("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"), "Outdoor category", "outdoor", "https://example.com/images/outdoor.jpg", "Outdoor", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"), "Hand Tools category", "hand tools", "https://example.com/images/hand_tools.jpg", "Hand Tools", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"), "Cameras category", "cameras", "https://example.com/images/cameras.jpg", "Cameras", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"), "Shoes category", "shoes", "https://example.com/images/shoes.jpg", "Shoes", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "Audio Devices category", "audio devices", "https://example.com/images/audio_devices.jpg", "Audio Devices", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[\"Type\",\"Noise Cancellation\",\"Battery Life\",\"Connectivity\"]", 0 },
                    { new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"), "Bedroom category", "bedroom", "https://example.com/images/bedroom.jpg", "Bedroom", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "Smartphones category", "smartphones", "https://example.com/images/smartphones.jpg", "Smartphones", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[\"Display\",\"Battery\",\"Camera\",\"Storage\"]", 0 },
                    { new Guid("d94af679-24f4-4ab2-ae1e-ba3689143579"), "Storage category", "storage", "https://example.com/images/storage.jpg", "Storage", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "WTL-001", null, "[\"https://example.com/products/makita1.jpg\",\"https://example.com/products/makita2.jpg\"]", "Makita Cordless Hammer Drill", 229.99m, 50, 4.5m, 100, 0 },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "FUR-001", null, "[\"https://example.com/products/coffee_table1.jpg\",\"https://example.com/products/coffee_table2.jpg\"]", "Modern Wooden Coffee Table", 149.99m, 50, 4.5m, 100, 0 },
                    { new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "HOU-001", null, "[\"https://example.com/products/dyson1.jpg\",\"https://example.com/products/dyson2.jpg\"]", "Dyson V15 Detect Vacuum Cleaner", 699.0m, 50, 4.5m, 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("07d62dcb-0736-4687-b066-92c3cde5fa9d"), "Battery", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "2 x 5.0Ah Li-ion" },
                    { new Guid("163febea-12c5-4ba7-af3e-5b3d5fa01e4f"), "Weight", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "18kg" },
                    { new Guid("4946c132-8ec4-41ce-891d-4788067a4a66"), "Finish", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "Natural varnish" },
                    { new Guid("50c7325d-5a50-4494-8356-c4ae304e70f5"), "Dimensions", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "120x60x45 cm" },
                    { new Guid("5a29ac69-487d-4609-b29e-3b6f30b088ce"), "Type", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "Cordless" },
                    { new Guid("7ba0bf0e-ed40-4e27-a0ac-85dd45279867"), "Battery Life", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "60 minutes" },
                    { new Guid("7c252a25-5c76-4e8b-be65-22e8651667ed"), "Dustbin Capacity", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "0.76L" },
                    { new Guid("90bba9ca-cc95-405e-8a8e-da471eafcde2"), "Chuck Size", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "13mm" },
                    { new Guid("a6a26067-18e9-4543-8828-8069f09a411f"), "Material", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), "Oak wood" },
                    { new Guid("b559db54-4289-499f-88dc-35a4c9978e4c"), "Power", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), "230AW" },
                    { new Guid("e0e1e5c9-55d8-4d16-bca2-e45a0d3553cc"), "Voltage", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "18V" },
                    { new Guid("f46c7e06-8dfe-48e9-b47e-9953e159ae69"), "Speed", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), "0-2000 RPM" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("1822758b-de5a-4f53-aea5-c624d90add9b"), "Intelligent optimization", "Efficiency", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("35198d10-7fbf-4919-aa3f-527c7e76abcb"), "Sleek and minimal", "Design", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("49b29ac4-ed20-4592-8690-304aa1e80df3"), "High torque for tough jobs", "Performance", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("6334b668-3933-4abb-8d5d-4324bb4ed08a"), "Solid wood construction", "Durability", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("75e0cc52-9a6b-4157-b453-57f390790cf4"), "Laser detects microscopic dust", "Performance", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("7c49174a-ea92-4119-b3bb-2951ffbaba67"), "Multiple attachments included", "Tools", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("8166c8f2-21fd-439c-ad3f-1eabe29bc76f"), "Ergonomic grip", "Comfort", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("9b6befa0-ebf3-4701-a70c-a8bb3c8689a1"), "Whole-machine HEPA filtration", "Filter", new Guid("a055168e-3130-4b0a-8495-60e25d62e057") },
                    { new Guid("a3c061b9-91f9-4d01-be37-4eb05da33ac5"), "Metal gear housing", "Durability", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("b6e56093-2fc5-473d-818a-26a9e5b52f82"), "Easy to wipe clean", "Maintenance", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") },
                    { new Guid("c4c5a991-e2cd-4d1b-a176-036f70667cb7"), "For dark areas", "LED Light", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc") },
                    { new Guid("f4eb7825-2ffd-4d1f-a9ba-5635ea698534"), "Quick setup included", "Assembly", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "SAM-001", null, "[\"https://example.com/products/samsung1.jpg\",\"https://example.com/products/samsung2.jpg\"]", "Samsung Galaxy S23 Ultra", 1199.99m, 50, 4.5m, 100, 0 },
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "SONY-002", null, "[\"https://example.com/products/sony1.jpg\",\"https://example.com/products/sony2.jpg\"]", "Sony WH-1000XM5 Headphones", 349.99m, 50, 4.5m, 100, 0 },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "FAS-001", null, "[\"https://example.com/products/jacket1.jpg\",\"https://example.com/products/jacket2.jpg\"]", "Men's Denim Jacket", 69.99m, 50, 4.5m, 100, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"), "Connectivity", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Bluetooth 5.2" },
                    { new Guid("2d3c46bc-1bd0-45c0-a695-6b3ea0cea55d"), "Camera", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "200MP" },
                    { new Guid("31ed2059-8d7c-440e-849c-92b82fa07535"), "Display", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "6.8-inch AMOLED" },
                    { new Guid("34b80662-4ddf-44df-aeab-0a131d4ca441"), "Fit", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "Regular" },
                    { new Guid("45890b2d-4656-4bf5-bea8-8d68cef13afa"), "Storage", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "256GB" },
                    { new Guid("5d1af968-e023-4bf1-a58b-4d6701785946"), "Battery", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "5000mAh" },
                    { new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"), "Battery Life", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "30 hours" },
                    { new Guid("93731c22-16a2-4c9e-b4d8-3aa7485d5acb"), "Color", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "Blue" },
                    { new Guid("ac51bf93-88a8-4b39-b106-b8a7f5c4db92"), "Season", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "All seasons" },
                    { new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"), "Noise Cancellation", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Yes" },
                    { new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"), "Type", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Over-ear" },
                    { new Guid("f75be0e7-0d41-45e8-87d7-e53060c87cd4"), "Material", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "100% Cotton" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("015d3ed7-c231-405e-bbd2-ef99c8171603"), "Premium glass and metal", "Build", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("1e8754f1-993e-4586-b0df-d16475bcd262"), "All-day usage", "Battery Life", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("38c8f67f-7b05-4f06-8856-546a4e499d5c"), "Made to last", "Durability", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"), "Touch-enabled", "Controls", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"), "High-resolution audio", "Sound", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("7aeefca5-b681-41cf-baef-0ab5306f250a"), "Machine washable", "Care", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("905cdea9-9662-4f42-82d4-c0b24e957ee8"), "Pairs with any outfit", "Versatility", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("9f7ba4ac-9b83-41bc-9fc9-53896c0fcd17"), "Pro-grade camera system", "Camera Quality", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"), "Soft ear cushions", "Comfort", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("c6676eab-a776-4380-9b0e-a07b10da8236"), "Snapdragon 8 Gen 2", "Performance", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"), "Foldable design", "Portability", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("f7f4c40c-82d3-488f-bf1a-9094dc2048b0"), "Casual yet rugged", "Style", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLists_ProductId",
                table: "CartLists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLists_UserId",
                table: "CartLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_IsActive",
                table: "Collections",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifications_Email_Type",
                table: "EmailVerifications",
                columns: new[] { "Email", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifications_UserId",
                table: "EmailVerifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLikes_ReviewId",
                table: "ReviewLikes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_ProductId",
                table: "WishlistItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLists");

            migrationBuilder.DropTable(
                name: "CollectionFilters");

            migrationBuilder.DropTable(
                name: "EmailVerifications");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ReviewLikes");

            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
