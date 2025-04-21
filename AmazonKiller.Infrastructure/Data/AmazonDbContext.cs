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

    protected override void OnModelCreating(ModelBuilder b)
    {
        // ----- ProductCard -----
        b.Entity<ProductCard>(e =>
        {
            e.Property(pc => pc.Price).HasPrecision(18, 2);
        });

        // ----- Sale -----
        b.Entity<Sale>(e =>
        {
            e.Property(s => s.OldPrice).HasPrecision(18, 2);
            e.Property(s => s.NewPrice).HasPrecision(18, 2);
        });
        
        // ---------- Product ----------
        b.Entity<Product>(e =>
        {
            e.HasIndex(p => p.Code).IsUnique();
            // хранение List<string> в JSON‑столбце (EFCore>=8)
            e.PrimitiveCollection(p => p.ProductPics);

            e.Property(p => p.Price).HasPrecision(18, 2);
            e.Property(p => p.RowVersion).IsRowVersion();
        });

        // ---------- ReviewContent ----------
        b.Entity<ReviewContent>(e =>
        {
            e.PrimitiveCollection(r => r.FilePaths);   // ← одной строчки достаточно
        });

        // ---------- seed ----------
        SeedData.Seed(b);
    }
}