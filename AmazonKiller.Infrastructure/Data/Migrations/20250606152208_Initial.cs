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
                    ActivePropertyKeys = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "ActivePropertyKeys", "Description", "IconName", "ImageUrl", "Name", "ParentId", "PropertyKeys", "Status" },
                values: new object[,]
                {
                    { new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", "Furniture category", "sofa", "https://example.com/images/furniture.jpg", "Furniture", null, "[]", 0 },
                    { new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", "Fashion category", "hanger", "https://example.com/images/fashion.jpg", "Fashion", null, "[]", 0 },
                    { new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", "Electronics category", "computer", "https://example.com/images/electronics.jpg", "Electronics", null, "[]", 0 },
                    { new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", "Household category", "cleaning-spray", "https://example.com/images/household.jpg", "Household", null, "[]", 0 },
                    { new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", "Work tools category", "hammer", "https://example.com/images/worktools.jpg", "Work tools", null, "[]", 0 }
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
                columns: new[] { "Id", "ActivePropertyKeys", "Description", "IconName", "ImageUrl", "Name", "ParentId", "PropertyKeys", "Status" },
                values: new object[,]
                {
                    { new Guid("0e6feb3f-f795-4541-8cc6-7d7047951eb9"), "[]", "Kitchen Appliances category", null, "https://example.com/images/kitchen_appliances.jpg", "Kitchen Appliances", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 },
                    { new Guid("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"), "[]", "Tool Storage category", null, "https://example.com/images/tool_storage.jpg", "Tool Storage", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"), "[]", "Safety Gear category", null, "https://example.com/images/safety_gear.jpg", "Safety Gear", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("1b6f5f96-233d-4b82-b30f-27643f6b62eb"), "[]", "Cleaning Supplies category", null, "https://example.com/images/cleaning_supplies.jpg", "Cleaning Supplies", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 },
                    { new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"), "[]", "Power Tools category", null, "https://example.com/images/power_tools.jpg", "Power Tools", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"), "[]", "Laptops category", null, "https://example.com/images/laptops.jpg", "Laptops", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"), "[]", "Office Furniture category", null, "https://example.com/images/office_furniture.jpg", "Office Furniture", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"), "[]", "Bathroom category", null, "https://example.com/images/bathroom.jpg", "Bathroom", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 },
                    { new Guid("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"), "[]", "Accessories category", null, "https://example.com/images/accessories.jpg", "Accessories", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"), "[]", "Living Room category", null, "https://example.com/images/living_room.jpg", "Living Room", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("69f22c76-7202-44e6-9132-09fd09c55632"), "[]", "Women's Clothing category", null, "https://example.com/images/womens_clothing.jpg", "Women's Clothing", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "[]", "Men's Clothing category", null, "https://example.com/images/mens_clothing.jpg", "Men's Clothing", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"), "[]", "Outdoor category", null, "https://example.com/images/outdoor.jpg", "Outdoor", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"), "[]", "Hand Tools category", null, "https://example.com/images/hand_tools.jpg", "Hand Tools", new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "[]", 0 },
                    { new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"), "[]", "Cameras category", null, "https://example.com/images/cameras.jpg", "Cameras", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"), "[]", "Shoes category", null, "https://example.com/images/shoes.jpg", "Shoes", new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"), "[]", 0 },
                    { new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "[]", "Audio Devices category", null, "https://example.com/images/audio_devices.jpg", "Audio Devices", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"), "[]", "Bedroom category", null, "https://example.com/images/bedroom.jpg", "Bedroom", new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "[]", 0 },
                    { new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "[]", "Smartphones category", null, "https://example.com/images/smartphones.jpg", "Smartphones", new Guid("7ad3d843-1642-4e8a-a843-503928ef8154"), "[]", 0 },
                    { new Guid("d94af679-24f4-4ab2-ae1e-ba3689143579"), "[]", "Storage category", null, "https://example.com/images/storage.jpg", "Storage", new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "[]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "IsActive", "MaxPrice", "MinPrice", "Title" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000004"), new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "https://example.com/collections/tables.jpg", true, 160m, 120m, "Modern Coffee Tables" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "https://example.com/collections/makita.jpg", true, 250m, 200m, "Makita Power Tools" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Info_Delivery_Address_ApartmentNumber", "Info_Delivery_Address_City", "Info_Delivery_Address_Country", "Info_Delivery_Address_HouseNumber", "Info_Delivery_Address_Id", "Info_Delivery_Address_PostCode", "Info_Delivery_Address_State", "Info_Delivery_Address_Street", "Info_Delivery_Email", "Info_Delivery_FirstName", "Info_Delivery_LastName", "OrderNumber", "Status", "TotalPrice", "UserId", "Info_Id", "Info_OrderedAt", "Info_Payment_CardNumber", "Info_Payment_Cvv", "Info_Payment_ExpirationDate", "Info_Payment_PaymentType" },
                values: new object[,]
                {
                    { new Guid("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"), null, "Kyiv", "Ukraine", "45B", new Guid("00000000-0000-0000-0000-000000000a02"), "02000", null, "Central Ave", "olena@example.com", "Olena", "Rudenko", "ORD-1002", 4, 1489.96m, new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"), new Guid("00000000-0000-0000-0000-00000000c002"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0 },
                    { new Guid("4e6f98ed-d665-470b-992b-dd872c86abe2"), null, "Lviv", "Ukraine", "78C", new Guid("00000000-0000-0000-0000-000000000a03"), "79000", null, "Green Blvd", "ivan@example.com", "Ivan", "Petrenko", "ORD-1003", 4, 689.97m, new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"), new Guid("00000000-0000-0000-0000-00000000c003"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5555555555554444", "456", "08/26", 1 },
                    { new Guid("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"), null, "Odessa", "Ukraine", "123A", new Guid("00000000-0000-0000-0000-000000000a01"), "65000", null, "Main St", "pavlo@example.com", "Pavlo", "Babchynskyi", "ORD-1001", 4, 139.98m, new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"), new Guid("00000000-0000-0000-0000-00000000c001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4111111111111111", "123", "12/25", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"), "WTL-001", null, "[\"https://content2.rozetka.com.ua/goods/images/big/333625233.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/367185899.jpg\"]", "Makita Cordless Hammer Drill", 229.99m, 50, 0m, 0, 0 },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"), "FUR-001", null, "[\"https://cdn2.jysk.com/getimage/wd3.medium/256592\",\"https://cdn2.jysk.com/getimage/wd3.medium/254304\"]", "Modern Wooden Coffee Table", 149.99m, 50, 0m, 0, 0 },
                    { new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000004"), new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "HOU-007", null, "[\"https://ecosoft.ua/upload/resize_cache/iblock/d40/564_564_140cd750bba9870f18aada2478b24840a/ru_filtr_obratnogo_osmosa_ecosoft_standard_pro_mo550mecostd_ua_filtr_zvorotnogo_osmosu_ecosoft_stand.webp\",\"https://ecosoft.ua/upload/resize_cache/iblock/527/564_564_140cd750bba9870f18aada2478b24840a/mo550ecostd_1_opt.webp\",\"https://ecosoft.ua/upload/resize_cache/iblock/391/564_564_140cd750bba9870f18aada2478b24840a/mo550ecostd_4_opt.webp\"]", "AquaPro RO+UV+UF Water Purifier", 199.99m, 45, 0m, 0, 0 },
                    { new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000006"), new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "HOU-006", null, "[\"https://content.rozetka.com.ua/goods/images/big/529433930.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/469768391.jpg\"]", "Philips Series 3000i Air Purifier", 319.00m, 35, 0m, 0, 0 },
                    { new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), new Guid("8980e70c-3345-4885-8518-cfcda95b3078"), "HOU-001", null, "[\"https://content1.rozetka.com.ua/goods/images/big/396437112.jpg\",\"https://content.rozetka.com.ua/goods/images/big/396437105.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/396437106.jpg\"]", "Dyson V15 Detect Vacuum Cleaner", 699.0m, 50, 0m, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "CollectionFilters",
                columns: new[] { "CollectionId", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Finish", "Natural varnish" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Material", "Oak wood" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Battery", "2 x 5.0Ah Li-ion" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Voltage", "18V" }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "IsActive", "MaxPrice", "MinPrice", "Title" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "https://example.com/collections/galaxy.jpg", true, 1300m, 1000m, "Galaxy Highlights" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "https://example.com/collections/sony.jpg", true, 400m, 300m, "Sony Audio Bestsellers" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "https://example.com/collections/denim.jpg", true, 100m, 50m, "Denim Essentials" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "OrderedAt", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000b003"), new Guid("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 149.99m, new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), 2 },
                    { new Guid("00000000-0000-0000-0000-00000000b004"), new Guid("4e6f98ed-d665-470b-992b-dd872c86abe2"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 229.99m, new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000191"), "Technology", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000004"), "RO+UV+UF" },
                    { new Guid("00000000-0000-0000-0000-000000000192"), "Storage Capacity", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000004"), "8 Liters" },
                    { new Guid("00000000-0000-0000-0000-000000000193"), "Power", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000004"), "36W" },
                    { new Guid("00000000-0000-0000-0000-000000000481"), "Coverage Area", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000006"), "104 m²" },
                    { new Guid("00000000-0000-0000-0000-000000000482"), "CADR", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000006"), "400 m³/h" },
                    { new Guid("00000000-0000-0000-0000-000000000483"), "Filter Type", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000006"), "HEPA + Carbon" },
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
                    { new Guid("00000000-0000-0000-0000-000000000291"), "Removes bacteria, viruses, and TDS", "Purification", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000004") },
                    { new Guid("00000000-0000-0000-0000-000000000292"), "Wall-mounted with transparent cover", "Design", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000004") },
                    { new Guid("00000000-0000-0000-0000-000000000481"), "App control and air quality feedback", "Smart Features", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000006") },
                    { new Guid("00000000-0000-0000-0000-000000000482"), "Operates as low as 33 dB", "Silent Mode", new Guid("7777eeee-aaaa-bbbb-cccc-dddd00000006") },
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
                    { new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "BOSE-001", null, "[\"https://content2.rozetka.com.ua/goods/images/big/382915623.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/382915624.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/382915625.jpg\",\"https://content.rozetka.com.ua/goods/images/big/382915629.jpg\"]", "Bose QuietComfort Ultra", 379.99m, 35, 0m, 0, 0 },
                    { new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"), "HOU-002", null, "[\"https://m.media-amazon.com/images/I/31lXMBFhMpL._SX522_.jpg\"]", "Silicone Toilet Brush & Holder", 19.99m, 100, 0m, 0, 0 },
                    { new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"), "FUR-004", null, "[\"https://cdn1.jysk.com/getimage/wd3.medium/236364\",\"https://cdn1.jysk.com/getimage/wd3.medium/236369\",\"https://cdn1.jysk.com/getimage/wd3.medium/236365\"]", "Minimalist Bedside Table", 59.99m, 40, 0m, 0, 0 },
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "SAM-001", null, "[\"https://content.rozetka.com.ua/goods/images/big/398092199.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/398092200.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092201.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092202.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092203.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/398092204.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/398092205.jpg\",\"https://content.rozetka.com.ua/goods/images/big/398092206.jpg\"]", "Samsung Galaxy S23 Ultra", 1199.99m, 50, 0m, 0, 0 },
                    { new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"), "WTL-002", null, "[\"https://content2.rozetka.com.ua/goods/images/big/11956995.jpg\"]", "DeWalt DCD996 Cordless Drill", 199.99m, 60, 0m, 0, 0 },
                    { new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"), "WTL-003", null, "[\"https://specprom-kr.com.ua/image/cache/catalog/image/catalog/files/perchatki-mbs-pokrytye-nitrilom-tverdyj-manzhet-564x564.webp\"]", "Heavy-Duty Utility Gloves", 24.99m, 80, 0m, 0, 0 },
                    { new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), new Guid("69f22c76-7202-44e6-9132-09fd09c55632"), "FAS-002", null, "[\"https://static.zara.net/assets/public/5383/1e3a/567f4efa9ab2/540875121096/04772368808-p/04772368808-p.jpg?ts=1747906901087\\u0026w=750\",\"https://static.zara.net/assets/public/1739/0738/387f4ed59035/81ddaea8d349/04772368808-a2/04772368808-a2.jpg?ts=1747906905715\\u0026w=750\",\"https://static.zara.net/assets/public/6eda/d9b8/33b748b0941d/85074a50ec93/04772368808-a4/04772368808-a4.jpg?ts=1747906897381\\u0026w=563\"]", "Zara Floral Midi Dress", 89.99m, 70, 0m, 0, 0 },
                    { new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"), "ELE-005", null, "[\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/2/000202052_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/3/000202053_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/4/000202054_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/5/000202055_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/6/000202056_1054_1054.jpeg\"]", "Sony Alpha a6400 Mirrorless Camera", 899.99m, 25, 0m, 0, 0 },
                    { new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), new Guid("69f22c76-7202-44e6-9132-09fd09c55632"), "FAS-005", null, "[\"https://img.kwcdn.com/product/open/17a385505e6240aaa133bfb681d557a5-goods.jpeg?imageView2/2/w/800/q/70/format/webp\",\"https://img.kwcdn.com/product/open/61685065fd0e459d9af558fcf949ee83-goods.jpeg?imageView2/2/w/800/q/70/format/webp\"]", "Stylish Women's Summer Hat", 34.99m, 40, 0m, 0, 0 },
                    { new Guid("7777dddd-aaaa-bbbb-cccc-eeee00000003"), new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"), "FUR-006", null, "[\"https://cdn1.jysk.com/getimage/wd3.large/245914\",\"https://cdn1.jysk.com/getimage/wd3.large/245910\",\"https://cdn1.jysk.com/getimage/wd3.large/161839\",\"https://cdn1.jysk.com/getimage/wd3.large/161840\"]", "Solid Wood Bookshelf 5-Tier", 129.99m, 30, 0m, 0, 0 },
                    { new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001"), new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"), "ELE-006", null, "[\"https://images.samsung.com/is/image/samsung/p6pim/ua/qe55s95dauxua/gallery/ua-oled-s95d-qe55s95dauxua-544778064?$684_547_JPG$\",\"https://images.samsung.com/is/image/samsung/p6pim/ua/qe55s95dauxua/gallery/ua-oled-s95d-qe55s95dauxua-541007467?$684_547_JPG$\",\"https://images.samsung.com/is/image/samsung/p6pim/ua/qe55s95dauxua/gallery/ua-oled-s95d-qe55s95dauxua-544308036?$684_547_JPG$\"]", "Samsung QLED 4K Smart TV 55\"", 1099.99m, 15, 0m, 0, 0 },
                    { new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000002"), new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "FAS-006", null, "[\"https://content2.rozetka.com.ua/goods/images/big/331352901.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/331352912.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/331352917.jpg\"]", "Men's Genuine Leather Jacket", 179.99m, 20, 0m, 0, 0 },
                    { new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000005"), new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"), "TOOL-010", null, "[\"https://content1.rozetka.com.ua/goods/images/big/318774509.jpg\",\"https://content.rozetka.com.ua/goods/images/big/318774562.png\",\"https://content2.rozetka.com.ua/goods/images/big/318774588.jpg\"]", "Bosch GSB 180-LI Cordless Drill", 139.99m, 60, 0m, 0, 0 },
                    { new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"), "ELE-003", null, "[\"https://content2.rozetka.com.ua/goods/images/big/423031985.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/423031986.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/423031987.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/423031988.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/423031989.jpg\"]", "Lenovo ThinkPad X1 Carbon Gen 11", 1899.99m, 25, 0m, 0, 0 },
                    { new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), new Guid("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"), "FUR-003", null, "[\"https://kupistul.ua/public/upload/catalogGood/kreslo-flex-mesh-cherniy-cherniy-106850112-0995.jpg\",\"https://kupistul.ua/public/upload/catalogGoodPhoto/kreslo-flex-mesh-cherniy-cherniy-106850112-77445.jpg\",\"https://kupistul.ua/public/upload/catalogGoodPhoto/kreslo-flex-mesh-cherniy-cherniy-106850112-77446.jpg\"]", "Ergonomic Office Chair with Lumbar Support", 249.99m, 50, 0m, 0, 0 },
                    { new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), new Guid("0e6feb3f-f795-4541-8cc6-7d7047951eb9"), "HOU-003", null, "[\"https://content2.rozetka.com.ua/goods/images/big/378171578.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/378171579.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/378171580.jpg\"]", "Collapsible Laundry Basket", 19.99m, 100, 0m, 0, 0 },
                    { new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"), "TOOL-005", null, "[\"https://biko.ua/image/cache/catalog/product/19139/195700-500x500.jpg\",\"https://biko.ua/image/cache/catalog/product/19139/5bbab5-500x500.jpg\"]", "3M Safety Helmet H-700 Series", 35.99m, 150, 0m, 0, 0 },
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"), "SONY-002", null, "[\"https://content2.rozetka.com.ua/goods/images/big/296707484.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/296707485.jpg\"]", "Sony WH-1000XM5 Headphones", 349.99m, 50, 0m, 0, 0 },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"), "FAS-001", null, "[\"https://xcdn.next.co.uk/common/items/default/default/itemimages/3_4Ratio/product/lge/E66531s.jpg?im=Resize,width=750\",\"https://xcdn.next.co.uk/common/items/default/default/itemimages/3_4Ratio/product/lge/E66531s3.jpg?im=Resize,width=480\"]", "Men's Denim Jacket", 69.99m, 50, 0m, 0, 0 },
                    { new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"), "FUR-002", null, "[\"https://home-club.com.ua//images/thumbs/0018524_-_510.jpeg\",\"https://home-club.com.ua//images/thumbs/0310065_-.jpeg\",\"https://home-club.com.ua//images/thumbs/0043920_-.jpeg\"]", "IKEA LACK Coffee Table", 39.99m, 80, 0m, 0, 0 },
                    { new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"), "FAS-003", null, "[\"https://img.modivo.cloud/product(5/4/5/9/54595f77bbbe0dda2ded1c7a961e279ff9bd34a7_0000207922853_01_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp\",\"https://img.modivo.cloud/product(1/f/8/9/1f89d5521273cfa7afca6e03500f99cb54bb9501_0000207922853_03_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp\",\"https://img.modivo.cloud/product(6/d/0/0/6d009576160e83813798096c877e9b7ee1b329a5_0000207922853_02_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp\"]", "Nike Air Max 270 Women’s", 129.99m, 60, 0m, 0, 0 },
                    { new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"), "APP-002", null, "[\"https://content2.rozetka.com.ua/goods/images/big/524114081.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/524114107.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/524114117.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/524114126.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/524114144.jpg\"]", "Apple iPhone 15 Pro Max", 1399.99m, 40, 0m, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Article", "ImageUrls", "Message", "ProductId", "Rating", "Tags", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Stylish and solid", "[]", "Looks very elegant and feels sturdy. Love the natural finish.", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), 4.7m, "[\"design\",\"durability\"]", new Guid("2583c105-264b-45ee-a535-3b939f4dd428") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Beast of a drill", "[]", "Very powerful and long-lasting battery. Great for home use.", new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), 5.0m, "[\"power\",\"performance\"]", new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Impressive cleaning", "[]", "Powerful suction and laser feature is actually helpful.", new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), 4.8m, "[\"vacuum\",\"laser\"]", new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Simple and elegant", "[]", "Easy to assemble, light weight, looks clean and modern.", new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), 4.6m, "[\"design\",\"assembly\"]", new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98") }
                });

            migrationBuilder.InsertData(
                table: "WishlistItems",
                columns: new[] { "ProductId", "UserId", "AddedAt" },
                values: new object[,]
                {
                    { new Guid("a055168e-3130-4b0a-8495-60e25d62e057"), new Guid("2583c105-264b-45ee-a535-3b939f4dd428"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"), new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"), new Guid("b116a743-b108-494a-abb5-a0c9673edbef"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Material", "100% Cotton" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "OrderedAt", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-00000000b001"), new Guid("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.99m, new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), 2 },
                    { new Guid("00000000-0000-0000-0000-00000000b002"), new Guid("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1199.99m, new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "Resolution", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "24.2MP" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "Sensor", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "APS-C CMOS" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "Video", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "4K UHD" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "Lens Mount", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "Sony E-mount" },
                    { new Guid("00000000-0000-0000-0000-000000000141"), "Material", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "High-Density Polyethylene" },
                    { new Guid("00000000-0000-0000-0000-000000000142"), "Suspension", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "4-point ratchet" },
                    { new Guid("00000000-0000-0000-0000-000000000143"), "Ventilation", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000144"), "Standard", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "ANSI/ISEA Z89.1-2014" },
                    { new Guid("00000000-0000-0000-0000-000000000151"), "Screen Size", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001"), "55 inch" },
                    { new Guid("00000000-0000-0000-0000-000000000152"), "Resolution", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001"), "4K Ultra HD" },
                    { new Guid("00000000-0000-0000-0000-000000000153"), "Display Type", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001"), "QLED" },
                    { new Guid("00000000-0000-0000-0000-000000000154"), "Smart TV", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000161"), "Material", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000002"), "Genuine Leather" },
                    { new Guid("00000000-0000-0000-0000-000000000162"), "Color", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000002"), "Black" },
                    { new Guid("00000000-0000-0000-0000-000000000163"), "Size", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000002"), "M-XXL" },
                    { new Guid("00000000-0000-0000-0000-000000000181"), "Material", new Guid("7777dddd-aaaa-bbbb-cccc-eeee00000003"), "Pine Wood" },
                    { new Guid("00000000-0000-0000-0000-000000000182"), "Color", new Guid("7777dddd-aaaa-bbbb-cccc-eeee00000003"), "Walnut Brown" },
                    { new Guid("00000000-0000-0000-0000-000000000183"), "Shelves", new Guid("7777dddd-aaaa-bbbb-cccc-eeee00000003"), "5" },
                    { new Guid("00000000-0000-0000-0000-000000000261"), "Type", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000005"), "Cordless Drill" },
                    { new Guid("00000000-0000-0000-0000-000000000262"), "Battery", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000005"), "18V Li-ion" },
                    { new Guid("00000000-0000-0000-0000-000000000263"), "Max Torque", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000005"), "54 Nm" },
                    { new Guid("00000000-0000-0000-0000-000000000311"), "Material", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "Polyester" },
                    { new Guid("00000000-0000-0000-0000-000000000312"), "Capacity", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "60L" },
                    { new Guid("00000000-0000-0000-0000-000000000313"), "Foldable", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000314"), "Weight", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "0.5kg" },
                    { new Guid("00000000-0000-0000-0000-000000000321"), "Material", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "Mesh + Foam" },
                    { new Guid("00000000-0000-0000-0000-000000000322"), "Color", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "Black" },
                    { new Guid("00000000-0000-0000-0000-000000000323"), "Adjustable Height", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000324"), "Max Weight", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "120 kg" },
                    { new Guid("00000000-0000-0000-0000-000000000331"), "Material", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), "Straw" },
                    { new Guid("00000000-0000-0000-0000-000000000332"), "Color", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), "Beige" },
                    { new Guid("00000000-0000-0000-0000-000000000333"), "Size", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), "One Size Fits Most" },
                    { new Guid("14f8a2fd-5c20-439c-b65e-bd697c9ed75a"), "Closure", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "Velcro strap" },
                    { new Guid("184d5fd1-4e1d-42c2-9b58-d5d3c1b2235a"), "Fit", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Relaxed" },
                    { new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"), "Connectivity", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Bluetooth 5.2" },
                    { new Guid("1cf8cf59-8f36-4f7c-b332-97c68a4692c0"), "Color", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "White/Pink" },
                    { new Guid("27449383-41e3-45f2-84d4-df3d02ec949b"), "Type", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "Wall-mounted" },
                    { new Guid("2d3c46bc-1bd0-45c0-a695-6b3ea0cea55d"), "Camera", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "200MP" },
                    { new Guid("2edab99b-17f7-4b63-93c2-8b42066a7d99"), "Color", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "Oak" },
                    { new Guid("2f4073fd-5296-4d79-90dc-2532c6795bc5"), "Size", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "M, L, XL" },
                    { new Guid("31ed2059-8d7c-440e-849c-92b82fa07535"), "Display", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "6.8-inch AMOLED" },
                    { new Guid("34b80662-4ddf-44df-aeab-0a131d4ca441"), "Fit", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "Regular" },
                    { new Guid("39ecdb88-44b6-4995-8cb8-e48de889d243"), "Drawers", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "1 soft-close drawer" },
                    { new Guid("3a57dbde-0659-4377-a618-5477c3f1c6ae"), "Length", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Midi" },
                    { new Guid("3b15cf2c-d0a6-45bb-a99f-2f0fa66cf91c"), "Chip", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "A17 Pro" },
                    { new Guid("3d768f6d-11d5-4033-8b6e-c2674d37b44a"), "Pattern", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Floral" },
                    { new Guid("44c10d0d-414c-4a75-baff-b5246a6e688b"), "Noise Cancellation", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "Adaptive" },
                    { new Guid("45890b2d-4656-4bf5-bea8-8d68cef13afa"), "Storage", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "256GB" },
                    { new Guid("50983ef4-7586-4be1-a6c7-eac4c7fd90a7"), "CPU", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "Intel Core i7-1355U" },
                    { new Guid("5d1af968-e023-4bf1-a58b-4d6701785946"), "Battery", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), "5000mAh" },
                    { new Guid("6c6b5864-33a0-4ec0-9a7e-34d73d226289"), "Chuck Size", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "13mm" },
                    { new Guid("6fa61d21-700f-4c0e-a04f-c1a1a8a2745b"), "Battery Life", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "24 hours" },
                    { new Guid("75c1376d-1ae0-405f-a46d-15c805e3e212"), "Charging", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "USB-C Fast Charging" },
                    { new Guid("7aa17ee1-6b46-4d41-8ae2-4f2f2931e0aa"), "Finish", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "White" },
                    { new Guid("7b7ec203-7f23-47ae-80d1-20b7f936a160"), "Upper", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "Mesh + Synthetic" },
                    { new Guid("83cfd9cb-24a9-4056-bb90-85986b3b6310"), "Storage", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "256GB" },
                    { new Guid("87a5f690-bcb1-4c00-a649-cb40f907e6f3"), "Color", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "White/Grey" },
                    { new Guid("8b4a31cf-9690-4cbe-a30a-5c6365ab263f"), "Material", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "Synthetic leather + Spandex" },
                    { new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"), "Battery Life", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "30 hours" },
                    { new Guid("93731c22-16a2-4c9e-b4d8-3aa7485d5acb"), "Color", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "Blue" },
                    { new Guid("949da2bb-18d8-4b1c-8e8d-2f10f011d5f7"), "Material", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "Silicone + Plastic" },
                    { new Guid("a49880a3-4ba6-4bb0-8015-4bc83b6dbbcd"), "Camera", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "48MP Triple-lens" },
                    { new Guid("aa64df41-c001-4d1a-91b7-0807f2b5c0de"), "Type", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8"), "Over-ear" },
                    { new Guid("ac51bf93-88a8-4b39-b106-b8a7f5c4db92"), "Season", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "All seasons" },
                    { new Guid("adcccfb2-5f3b-44d2-b3bc-0091e084d27f"), "Display", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "14\" FHD+ IPS" },
                    { new Guid("b390fa02-66b0-4d7b-8f2c-046cd0c93187"), "RAM", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "16GB LPDDR5" },
                    { new Guid("b5bdf51b-e460-4e8a-8c44-22625f91ae45"), "Display", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5"), "6.7-inch OLED" },
                    { new Guid("b8bc8f7a-267f-43a8-b81e-360d250209c3"), "Speed", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "0–2000 RPM" },
                    { new Guid("bd929b9e-d115-41ea-8d6f-5f8c66200ac6"), "Material", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "Engineered wood" },
                    { new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"), "Noise Cancellation", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Yes" },
                    { new Guid("be3a6d15-cb6b-490a-87f1-6a54bd1614ec"), "Storage", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "512GB SSD" },
                    { new Guid("c1f7efb2-8dbb-4d6e-890b-91873cc0f8a2"), "Material", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5"), "Viscose" },
                    { new Guid("c2d1f858-b56c-487f-9a71-c04d6cba91e3"), "Outsole", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "Rubber" },
                    { new Guid("c8d6d4e7-3c25-41f4-9c3c-144143d3cb94"), "Material", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "Particleboard" },
                    { new Guid("c95c1143-dcb0-4010-80a0-4b260303f170"), "Color", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "Black/Yellow" },
                    { new Guid("ca0c370e-e27d-4ec6-89b2-1ed26b3db5c3"), "Size", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "US 6–10" },
                    { new Guid("d22b2c79-63f2-4c5f-888c-12d569df4455"), "Replaceable Head", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "Yes" },
                    { new Guid("e0701d10-c221-4032-b3a5-4a05c69f56c5"), "Weight", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "5.8kg" },
                    { new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"), "Type", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), "Over-ear" },
                    { new Guid("ec9f4ff8-dc66-4a6a-a88d-dfd03275e05a"), "Dimensions", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170"), "90x55 cm" },
                    { new Guid("f31206e4-8237-4db1-b3a0-544b26dd5865"), "Voltage", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "20V" },
                    { new Guid("f5035e59-f0f6-4db6-8160-0df17931a1c8"), "Battery", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2"), "2x 5.0Ah Li-ion" },
                    { new Guid("f75be0e7-0d41-45e8-87d7-e53060c87cd4"), "Material", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), "100% Cotton" },
                    { new Guid("fa9b7096-d331-4ed7-a45c-80e0b5d68242"), "Dimensions", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "45x40x50 cm" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000201"), "425 phase-detection points", "Autofocus", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "180° tiltable LCD", "Screen", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "Wi-Fi, NFC, Bluetooth", "Connectivity", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "Magnesium alloy body", "Build", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000241"), "Soft brow pad and adjustable fit", "Comfort", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000242"), "Impact-resistant outer shell", "Durability", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000243"), "Accessory slots for face shields and earmuffs", "Compatibility", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000251"), "Supports Bixby, Alexa, and Google Assistant", "Voice Control", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000252"), "Quantum HDR with deep contrast", "HDR", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000253"), "Slim look with almost no bezel", "Design", new Guid("7777eeee-ffff-aaaa-bbbb-cccc00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000261"), "Classic biker look with zipper closure", "Style", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000262"), "Fully lined for winter use", "Warmth", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000281"), "Supports up to 30kg per shelf", "Durability", new Guid("7777dddd-aaaa-bbbb-cccc-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000282"), "Rustic farmhouse design", "Style", new Guid("7777dddd-aaaa-bbbb-cccc-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000361"), "2-speed gearbox for optimized performance", "Speed", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000362"), "Robust housing and overload protection", "Durability", new Guid("7777ffff-aaaa-bbbb-cccc-dddd00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000401"), "Reinforced carry handles for easy transport", "Handles", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000402"), "Breathable mesh sides", "Design", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000403"), "Compact foldable design", "Storage", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000404"), "Ideal for dorms, apartments, or travel", "Use", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000421"), "Provides lumbar support and breathable mesh back", "Ergonomic Design", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000422"), "360° swivel and smooth rolling wheels", "Mobility", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000423"), "Adjustable height and tilt tension", "Adjustability", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000431"), "Wide brim blocks UV rays", "Sun Protection", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000432"), "Breathable and lightweight", "Design", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001") },
                    { new Guid("0072b22f-4b44-4c2b-8fe9-996e1b0aa832"), "Visible Air Max unit", "Cushioning", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("015d3ed7-c231-405e-bbd2-ef99c8171603"), "Premium glass and metal", "Build", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("06695e1f-8d42-498c-8d34-e3281d49753b"), "Cinematic mode & Night photography", "Camera System", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("146e8860-5f1a-4086-85a1-bcbe5e16a982"), "Tool-free assembly", "Assembly", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("19738491-3030-4b3b-9819-353117c4fc5e"), "Quick-drying ventilation base", "Hygiene", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("1a2ef03d-456e-4edb-a7b0-31a7088b0596"), "Flexible and snug fit", "Fit", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("1c6c2255-9535-4520-84ee-b00db4a2225d"), "Ergonomic handle", "Grip", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("1e4cc7b4-51a5-4bfb-8e36-1ce9a2a6c8b0"), "Brushless motor", "Performance", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("1e8754f1-993e-4586-b0df-d16475bcd262"), "All-day usage", "Battery Life", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("2a222bb7-cc32-4e2f-9ad3-2ad2aaf1fc6f"), "Heavy-duty construction", "Durability", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("2bda4a7f-cd79-47b1-94bb-d237e52794ae"), "Sporty & stylish", "Design", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("2e5c6e3a-bb5f-42f7-b933-0e21dcdb267f"), "Plush cushioning", "Comfort", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("34233ac6-0e32-42b1-9e4f-7c83bcd8fd5f"), "Reinforced knuckles", "Protection", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("38c8f67f-7b05-4f06-8856-546a4e499d5c"), "Made to last", "Durability", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("431d02bb-1446-4d9a-8f71-207b6d0ffbe1"), "Simple and modern", "Design", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("4a1174ed-faf9-41de-9769-98a7c31560ef"), "Flexible anti-scratch bristles", "Durability", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"), "Touch-enabled", "Controls", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("56e75d3f-9fb5-4d8c-a986-8985a8aa96c1"), "Titanium frame", "Build Quality", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("60e84a9a-e016-4654-a8e4-24e48dc26156"), "Compact storage", "Convenience", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("6ab182fd-45bb-4747-93d7-4533cdd9f88c"), "LED work light", "Convenience", new Guid("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2") },
                    { new Guid("6b747748-3a2a-4c1a-a1b3-8e7d7dbba1f1"), "Textured palm for firm hold", "Grip", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("71f2be1d-44a1-4216-96c5-589cba78d144"), "Perforated upper", "Breathability", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("76bdc733-91d3-48f1-a447-b78e0e4b9991"), "Smooth iOS experience", "Performance", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("781153a3-0555-49ae-987e-09dbde5172ee"), "Suitable for casual and formal", "Versatility", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"), "High-resolution audio", "Sound", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("7aeefca5-b681-41cf-baef-0ab5306f250a"), "Machine washable", "Care", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("8412c1ff-2650-42e3-844b-9a1c36522aa4"), "Foam midsole", "Comfort", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("905cdea9-9662-4f42-82d4-c0b24e957ee8"), "Pairs with any outfit", "Versatility", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("93c3210e-48e6-4fc4-8783-47bdc8601694"), "Touch & voice control", "Controls", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("960b60da-6796-46ce-bb6f-6cc84ef70f1f"), "Legendary ThinkPad tactile typing", "Keyboard", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("9c7ad3cf-06f1-4a96-844f-f7c6ae5e0249"), "15+ hour runtime", "Battery", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("9f179493-b4d6-4a53-bdc1-d5dd3fa189e3"), "Easy clean surface", "Maintenance", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("9f7ba4ac-9b83-41bc-9fc9-53896c0fcd17"), "Pro-grade camera system", "Camera Quality", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("a3a37d1e-26e9-40f0-b935-1e5e43b83e02"), "Budget-friendly option", "Affordability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("a40b5a25-8d40-47d5-b509-cf01d6cb44f6"), "No-drill installation", "Convenience", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("a5fd738e-6d61-49f7-b51c-dcdbbcd27644"), "Breathable fabric", "Comfort", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("a90fa301-e8e3-4097-a507-cdc1a9f5b008"), "Lightweight design", "Portability", new Guid("b7a6497f-c4cb-4d7c-afe5-167c02cbf170") },
                    { new Guid("aeef3fa9-5e61-4bb8-8bff-2b5884c32596"), "Ultra-light carbon fiber body", "Portability", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"), "Soft ear cushions", "Comfort", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("b8b470f9-3720-4a95-918b-02f6ddbb0f5d"), "Reusable & replaceable head", "Eco-Friendly", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("b9b205bb-9a76-4456-a0cb-dc28e4fce1c5"), "Elegant and breezy", "Style", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") },
                    { new Guid("c6676eab-a776-4380-9b0e-a07b10da8236"), "Snapdragon 8 Gen 2", "Performance", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a") },
                    { new Guid("d891dc16-0e25-4412-b43f-e5f5e2450a70"), "Fingerprint + IR camera", "Security", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("da2c2ff2-1c38-4a23-a8cc-25b4f4ec2680"), "Modern aesthetic", "Design", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("de2955e6-e21e-4ed2-a65e-3b73f708dd7a"), "Mesh back panel", "Breathability", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("e4c01f56-8e2e-4866-a98f-6c4f69f63f6f"), "Up to 29 hours video playback", "Battery Life", new Guid("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5") },
                    { new Guid("e7a8d1a9-30a1-4b89-80d3-90e5a948d914"), "DIY friendly", "Assembly", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"), "Foldable design", "Portability", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa") },
                    { new Guid("f00725dc-2d23-4ff3-93b6-bcb9fdf8f293"), "CustomTune technology", "Sound Quality", new Guid("12a5f27a-59d1-4961-86d7-14a787f8eec8") },
                    { new Guid("f2f2c8fb-0f90-420c-9ed1-5947728f615a"), "Modern minimalist", "Style", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("f7f4c40c-82d3-488f-bf1a-9094dc2048b0"), "Casual yet rugged", "Style", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b") },
                    { new Guid("fbf426f5-78e4-4d4f-b183-3fcf3870e04b"), "Machine washable", "Care", new Guid("6f4c984f-7baf-4a39-aab3-018202f20de5") }
                });

            migrationBuilder.InsertData(
                table: "ReviewLikes",
                columns: new[] { "ReviewId", "UserId", "LikedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("2583c105-264b-45ee-a535-3b939f4dd428"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Article", "ImageUrls", "Message", "ProductId", "Rating", "Tags", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Excellent phone", "[]", "Battery lasts all day. The screen is incredibly bright and vivid.", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), 5.0m, "[\"battery\",\"screen\"]", new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Good but expensive", "[]", "Features are great, but the price is a bit high.", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), 4.0m, "[\"price\"]", new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Top sound quality", "[]", "Perfect for flights. Noise cancelling works like magic.", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), 5.0m, "[\"sound\",\"noise cancelling\"]", new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Comfortable", "[]", "Long usage with no discomfort. Battery could be better though.", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), 4.2m, "[\"comfort\",\"battery\"]", new Guid("b116a743-b108-494a-abb5-a0c9673edbef") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Classic style", "[]", "Fits perfectly and looks good with anything. My go-to jacket.", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), 4.9m, "[\"fit\",\"style\"]", new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Camera is next level", "[]", "200MP might be overkill, but wow, it delivers detail.", new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), 4.9m, "[\"camera\"]", new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Good value", "[]", "High-quality fabric, didn’t expect it for this price.", new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), 4.4m, "[\"value\",\"material\"]", new Guid("2583c105-264b-45ee-a535-3b939f4dd428") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Not for running", "[]", "Slips off easily if you're jogging. Great otherwise.", new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), 3.9m, "[\"use case\"]", new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef") }
                });

            migrationBuilder.InsertData(
                table: "WishlistItems",
                columns: new[] { "ProductId", "UserId", "AddedAt" },
                values: new object[,]
                {
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"), new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"), new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"), new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ReviewLikes",
                columns: new[] { "ReviewId", "UserId", "LikedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("b116a743-b108-494a-abb5-a0c9673edbef"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("b116a743-b108-494a-abb5-a0c9673edbef"), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
