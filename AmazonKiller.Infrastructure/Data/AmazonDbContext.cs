using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data;

public class AmazonDbContext(DbContextOptions<AmazonDbContext> options) : DbContext(options)
{
    public DbSet<Sequence> Sequences => Set<Sequence>();

    public DbSet<Category> Categories => Set<Category>();


    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductFeature> ProductFeatures => Set<ProductFeature>();


    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<EmailVerification> EmailVerifications => Set<EmailVerification>();
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();


    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ReviewLike> ReviewLikes => Set<ReviewLike>();


    public DbSet<Wishlist> WishlistItems => Set<Wishlist>();
    public DbSet<CartList> CartLists => Set<CartList>();

    public DbSet<Collection> Collections => Set<Collection>();


    protected override void OnModelCreating(ModelBuilder b)
    {
        // Подключаем все конфигурации из текущей сборки
        b.ApplyConfigurationsFromAssembly(typeof(AmazonDbContext).Assembly);

        // Seed 
        SeedData.Seed(b);
    }
}