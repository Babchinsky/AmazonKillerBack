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
        // Указываем precision для нужных полей
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ProductCard>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Sale>()
            .Property(s => s.OldPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Sale>()
            .Property(s => s.NewPrice)
            .HasPrecision(18, 2);

        SeedData.Seed(modelBuilder);
    }
}