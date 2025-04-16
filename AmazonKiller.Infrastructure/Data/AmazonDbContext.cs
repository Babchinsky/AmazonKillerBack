using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Domain.Entities.Sales;
using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data;

public class AmazonDbContext(DbContextOptions<AmazonDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ProductCard> ProductCards => Set<ProductCard>();
    public DbSet<ProductDetails> ProductDetails => Set<ProductDetails>();
    public DbSet<ReviewContent> ReviewContents => Set<ReviewContent>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    public DbSet<CartList> CartLists => Set<CartList>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка точности decimal для цены
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
        modelBuilder.Entity<ProductCard>().Property(p => p.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Sale>().Property(p => p.OldPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Sale>().Property(p => p.NewPrice).HasPrecision(18, 2);
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Details)
            .WithMany()
            .HasForeignKey(p => p.DetailsId);

        // Пример сидинга Category
        var categoryId = new Guid("11111111-1111-1111-1111-111111111111");
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = categoryId,
            Name = "Books"
        });

        // Сидинг ProductDetails
        var detailsId = new Guid("33333333-3333-3333-3333-333333333333");
        modelBuilder.Entity<ProductDetails>().HasData(new ProductDetails
        {
            Id = detailsId,
            FabricType = "Paper",
            CareInstructions = "Keep dry",
            Origin = "USA",
            ClosureType = "None",
            Brand = Brands.ASOS,
            Color = Colors.White,
            ClothesSize = null,
            ShoesSize = null
        });

        // Сидинг Product (без списка картинок)
        var productId = new Guid("22222222-2222-2222-2222-222222222222");
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "C# in Depth",
            Price = 39.99m,
            ReviewsCount = 0,
            Quantity = 10,
            Status = ProductStatus.InStock,
            Rating = Rating.Five,
            CategoryId = categoryId,
            InWishlist = false,
            InCartList = false,
            DetailsId = detailsId 
        });

    }
}
