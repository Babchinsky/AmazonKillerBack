using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Статические значения для GUID
        var booksId = new Guid("11111111-1111-1111-1111-111111111111");
        var techId = new Guid("22222222-2222-2222-2222-222222222222");

        var details1 = new Guid("33333333-3333-3333-3333-333333333333");
        var details2 = new Guid("44444444-4444-4444-4444-444444444444");

        var product1 = new Guid("55555555-5555-5555-5555-555555555555");
        var product2 = new Guid("66666666-6666-6666-6666-666666666666");

        var userId = new Guid("77777777-7777-7777-7777-777777777777");
        var adminId = new Guid("88888888-8888-8888-8888-888888888888");

        var reviewContentId = new Guid("99999999-9999-9999-9999-999999999999");
        var reviewId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        var cartId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = booksId,
                Name = "Books",
                Status = CategoryStatus.Active,
                Description = "A selection of books",
                ImageUrl = "https://example.com/images/books.jpg",
                IconName = "book", // так как это main category
                ParentId = null
            },
            new Category
            {
                Id = techId,
                Name = "Tech",
                Status = CategoryStatus.Active,
                Description = "Tech gadgets and accessories",
                ImageUrl = "https://example.com/images/tech.jpg",
                IconName = "devices", // тоже main category
                ParentId = null
            }
        );

        // ProductDetails
        modelBuilder.Entity<ProductDetails>().HasData(
            new ProductDetails
            {
                Id = details1,
                FabricType = "Paper",
                CareInstructions = "Keep dry",
                Origin = "USA",
                ClosureType = "None",
                Brand = Brands.ASOS,
                Color = Colors.White
            },
            new ProductDetails
            {
                Id = details2,
                FabricType = "Plastic",
                CareInstructions = "Wipe clean",
                Origin = "China",
                ClosureType = "Zip",
                Brand = Brands.Nike,
                Color = Colors.Black
            }
        );

        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = product1,
                Code = "01JS9QNDAYKK2CFRT5AKZF1YAA",
                Name = "C# in Depth",
                Price = 39.99m,
                ReviewsCount = 1,
                Quantity = 10,
                Status = ProductStatus.InStock,
                Rating = Rating.Five,
                CategoryId = booksId,
                InWishlist = true,
                InCartList = true,
                DetailsId = details1
            },
            new Product
            {
                Id = product2,
                Code = "01JS9QNDAYKK2CFRT5AKZF1YBB",
                Name = "Wireless Mouse",
                Price = 19.99m,
                ReviewsCount = 0,
                Quantity = 50,
                Status = ProductStatus.InStock,
                Rating = Rating.Four,
                CategoryId = techId,
                InWishlist = false,
                InCartList = false,
                DetailsId = details2
            }
        );

        // Users
        const string fixedSalt = "$2a$11$0123456789ABCDEFFEDCBA";
        var userPasswordHash = BCrypt.Net.BCrypt.HashPassword("User123!", fixedSalt);
        var adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!", fixedSalt);
        var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = userId,
                Email = "user@example.com",
                PasswordHash = userPasswordHash,
                FirstName = "Test",
                LastName = "User",
                Role = Role.Customer,
                Status = UserStatus.Active,
                CreatedAt = seedDate
            },
            new User
            {
                Id = adminId,
                Email = "admin@example.com",
                PasswordHash = adminPasswordHash,
                FirstName = "Admin",
                LastName = "Root",
                Role = Role.Admin,
                Status = UserStatus.Active,
                CreatedAt = seedDate
            }
        );

        // Wishlist
        modelBuilder.Entity<Wishlist>().HasData(
            new Wishlist
            {
                UserId = userId,
                ProductId = product1,
                AddedAt = seedDate // Статическая дата
            }
        );

        // CartList
        modelBuilder.Entity<CartList>().HasData(
            new CartList
            {
                Id = cartId,
                UserId = userId,
                ProductId = product1,
                Quantity = 1,
                Price = 39.99m,
                AddedAt = seedDate // Статическая дата
            }
        );

        // ReviewContent
        modelBuilder.Entity<ReviewContent>().HasData(
            new ReviewContent
            {
                Id = reviewContentId,
                Article = "Great book!",
                Message = "Very useful for learning advanced C#",
                FilePaths = ["file1.jpg", "file2.jpg"] // Статический список строк
            }
        );

        // Review
        modelBuilder.Entity<Review>().HasData(new Review
        {
            Id = reviewId,
            ContentId = reviewContentId,
            ProductId = product1,
            UserId = userId,
            Rating = Rating.Five,
            CreatedAt = seedDate, // Статическая дата
            Likes = 3
        });
    }
}