using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed;

public static class UsersSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"),
                Email = "michaelterrell1@example.com",
                PasswordHash = "$2b$12$JthvV5eK9b0BX972kty2PuNuUd4Nk3wGLklIlj0HX2wInNS/78H7u",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Kathy",
                LastName = "Thomas",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                Email = "april992@example.com",
                PasswordHash = "$2b$12$smw9z353sKgENxXVnQs6g.1EHa6UYkFh9jpq/ILRjrzDzY5lS9Nxa",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Amanda",
                LastName = "Decker",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"),
                Email = "mjones3@example.com",
                PasswordHash = "$2b$12$XL/cSsxTSvYunP0ws3PTfOowebceqDPLauAE1qJcpljQwPgXXvTIG",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Samantha",
                LastName = "Moore",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("b116a743-b108-494a-abb5-a0c9673edbef"),
                Email = "heather934@example.com",
                PasswordHash = "$2b$12$KPKg2yfoi0KQriKvrpKtYe3lGI67jJMkfncwg79HN1K0ln/PQwkym",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Brittany",
                LastName = "Edwards",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("2583c105-264b-45ee-a535-3b939f4dd428"),
                Email = "suzannegonzalez5@example.com",
                PasswordHash = "$2b$12$bUoOhVkj0HkDTCZlh8/n9O2m7s7.FwtwsJYj4fiR4OnZN2cKl9S9K",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Jennifer",
                LastName = "Delacruz",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"),
                Email = "kimberly906@example.com",
                PasswordHash = "$2b$12$zhpKLnHJl9jZxDcwwGhbyO8yDViIlu0E.WrbucVxYqfSvZxJqIMzm",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Daniel",
                LastName = "Kaiser",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"),
                Email = "eric737@example.com",
                PasswordHash = "$2b$12$hZMooIIRDBrx/2SZ9FbS9uuT/M4esP1.z1UFFvLHfKrcLYLccRTz6",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "John",
                LastName = "Hernandez",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"),
                Email = "hallshaun8@example.com",
                PasswordHash = "$2b$12$B./Bh7QhdcmttuAWXIt8dOp5Hul0w7YjOCMBCnGUfHQV4NvKfQ8Xe",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Charles",
                LastName = "Cook",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"),
                Email = "cannonkelly9@example.com",
                PasswordHash = "$2b$12$r9HYkq1hv0wiwZh05W6fq.6b3qoZxXrOfr/xrFSA//x69Qu77mOJO",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Christopher",
                LastName = "Salazar",
                ImageUrl = null
            },
            new User
            {
                Id = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                Email = "nparrish10@example.com",
                PasswordHash = "$2b$12$ix2jyWO01HHxwhtmLFIFXO/JbQ8eqT.IaJw5xrGAgcXbN/HL7ZIZO",
                Role = Role.Customer,
                Status = UserStatus.Active,
                FirstName = "Jason",
                LastName = "Meza",
                ImageUrl = null
            }
        );
    }
}