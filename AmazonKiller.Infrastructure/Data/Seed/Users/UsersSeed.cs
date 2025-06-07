using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Users;

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
                ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/038/962/461/small/ai-generated-caucasian-successful-confident-young-businesswoman-ceo-boss-bank-employee-worker-manager-with-arms-crossed-in-formal-wear-isolated-in-white-background-photo.jpg"
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
                ImageUrl = "https://media.istockphoto.com/id/1326417862/ru/%D1%84%D0%BE%D1%82%D0%BE/%D0%BC%D0%BE%D0%BB%D0%BE%D0%B4%D0%B0%D1%8F-%D0%B6%D0%B5%D0%BD%D1%89%D0%B8%D0%BD%D0%B0-%D1%81%D0%BC%D0%B5%D0%B5%D1%82%D1%81%D1%8F-%D0%B2%D0%BE-%D0%B2%D1%80%D0%B5%D0%BC%D1%8F-%D0%BE%D1%82%D0%B4%D1%8B%D1%85%D0%B0-%D0%B4%D0%BE%D0%BC%D0%B0.jpg?s=612x612&w=0&k=20&c=S5kj1xMVROvdovQaZ2zkL5ydZM0M32V7lBpe86VVuNQ="
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
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Woman_at_Lover%27s_Bridge_Tanjung_Sepat_%28cropped%29.jpg/1200px-Woman_at_Lover%27s_Bridge_Tanjung_Sepat_%28cropped%29.jpg"
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
                ImageUrl = "https://discoverymood.com/wp-content/uploads/2020/04/Mental-Strong-Women-min-480x340.jpg"
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
                ImageUrl = "https://img.freepik.com/free-photo/young-beautiful-woman-pink-warm-sweater-natural-look-smiling-portrait-isolated-long-hair_285396-896.jpg?semt=ais_hybrid&w=740"
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
                ImageUrl = "https://images.pexels.com/photos/2379004/pexels-photo-2379004.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
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
                ImageUrl = "https://static.vecteezy.com/system/resources/thumbnails/005/346/410/small_2x/close-up-portrait-of-smiling-handsome-young-caucasian-man-face-looking-at-camera-on-isolated-light-gray-studio-background-photo.jpg"
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
                ImageUrl = "https://media.istockphoto.com/id/1388648617/photo/confident-caucasian-young-man-in-casual-denim-clothes-with-arms-crossed-looking-at-camera.jpg?s=612x612&w=0&k=20&c=YxctPklAOJMmy6Tolyvn45rJL3puk5RlKt39FO46ZeA="
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
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHg0mkcVvR4xO0RpIJfAzLmfC5QE52D9mIAA&s"
            }
        );
    }
}