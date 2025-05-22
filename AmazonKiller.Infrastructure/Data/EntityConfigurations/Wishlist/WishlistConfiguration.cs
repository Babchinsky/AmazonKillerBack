using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Wishlist;

public class WishlistConfiguration : IEntityTypeConfiguration<Domain.Entities.Users.Wishlist>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Users.Wishlist> b)
    {
        b.HasKey(w => new { w.UserId, w.ProductId });

        b.HasOne(w => w.User)
            .WithMany(u => u.Wishlists)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(w => w.Product)
            .WithMany()
            .HasForeignKey(w => w.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Property(w => w.AddedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();
    }
}