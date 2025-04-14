using AmazonKillerBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmazonKillerBack.Infrastructure.Data;

public class AmazonDbContext(DbContextOptions<AmazonDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Review> Reviews => Set<Review>();
    // public DbSet<CartItem> CartItems => Set<CartItem>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = new Guid("11111111-1111-1111-1111-111111111111"),
            Name = "Books"
        });

        // modelBuilder.Entity<Product>().HasData(new Product
        // {
        //     Id = new Guid("22222222-2222-2222-2222-222222222222"),
        //     Name = "C# in Depth",
        //     Description = "A deep dive into C#",
        //     Price = 39.99m,
        //     Stock = 10,
        //     ImageUrl = null,
        //     CategoryId = new Guid("11111111-1111-1111-1111-111111111111")
        // });
    }

}