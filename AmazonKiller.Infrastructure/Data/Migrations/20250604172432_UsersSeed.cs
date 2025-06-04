using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UsersSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2583c105-264b-45ee-a535-3b939f4dd428"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b116a743-b108-494a-abb5-a0c9673edbef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"));
        }
    }
}
