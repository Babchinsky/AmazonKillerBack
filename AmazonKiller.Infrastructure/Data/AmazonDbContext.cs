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
    public DbSet<Wishlist> WishlistItems => Set<Wishlist>();
    public DbSet<CartList> CartLists => Set<CartList>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<EmailVerification> EmailVerifications => Set<EmailVerification>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        // Подключаем все конфигурации из текущей сборки
        b.ApplyConfigurationsFromAssembly(typeof(AmazonDbContext).Assembly);

        // AmazonKiller.Infrastructure/Data/AmazonDbContext.cs  (OnModelCreating)
        b.Entity<ProductAttribute>(entityTypeBuilder =>
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Key).HasMaxLength(30).IsRequired();
            entityTypeBuilder.Property(x => x.Value).HasMaxLength(30).IsRequired();
            entityTypeBuilder.HasOne(x => x.Product)
                .WithMany(p => p.Attributes)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        b.Entity<ProductFeature>(entityTypeBuilder =>
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(60).IsRequired();
            entityTypeBuilder.Property(x => x.Description).HasMaxLength(300).IsRequired();
            entityTypeBuilder.HasOne(x => x.Product)
                .WithMany(p => p.Features)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });


        // Seed 
        SeedData.Seed(b);
    }
}