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
        // ----- ProductCard -----
        b.Entity<ProductCard>(e => { e.Property(pc => pc.Price).HasPrecision(18, 2); });

        // ----- Sale -----
        b.Entity<Sale>(e =>
        {
            e.Property(s => s.OldPrice).HasPrecision(18, 2);
            e.Property(s => s.NewPrice).HasPrecision(18, 2);
        });

        // ---------- Products ----------
        b.Entity<Product>(e =>
        {
            e.HasIndex(p => p.Code).IsUnique();
            e.PrimitiveCollection(p => p.ProductPics);
            e.Property(p => p.Price).HasPrecision(18, 2);
            e.Property(p => p.RowVersion).IsRowVersion();
        });

        // ---------- Order ----------
        b.Entity<Order>(e =>
        {
            e.Property(o => o.TotalPrice).HasPrecision(18, 2); // ← добавь это
        });

        // ---------- OrderItem ----------
        b.Entity<OrderItem>(e =>
        {
            e.Property(oi => oi.Price).HasPrecision(18, 2); // ← и это
        });

        // ---------- ReviewContent ----------
        b.Entity<ReviewContent>(e => { e.PrimitiveCollection(r => r.FilePaths); });

        // ---------- CartList ----------
        b.Entity<CartList>(e =>
        {
            e.HasOne(cl => cl.Product)
                .WithMany()
                .HasForeignKey(cl => cl.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            e.Property(cl => cl.Price).HasPrecision(18, 2);
        });

        // ---------- Wishlist ----------
        b.Entity<Wishlist>(e =>
        {
            e.HasKey(w => new { w.UserId, w.ProductId });

            e.HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(w => w.Product)
                .WithMany()
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });


        b.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()"); // для SQL Server


        // Order -> OrderInfo (owned)
        b.Entity<Order>().OwnsOne(o => o.Info, info =>
        {
            info.OwnsOne(i => i.Delivery, delivery => { delivery.OwnsOne(d => d.Address); });

            info.OwnsOne(i => i.Payment);
        });

        // ---------- Categories (hierarchy) ----------
        b.Entity<Category>(e =>
        {
            e.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // не рвём ветку каскадом

            e.Property(c => c.Status)
                .HasDefaultValue(CategoryStatus.Active);

            e.Property(c => c.Name).HasMaxLength(40);
        });


        // ---------- seed ----------
        SeedData.Seed(b);
    }
}