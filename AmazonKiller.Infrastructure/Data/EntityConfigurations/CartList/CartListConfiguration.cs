using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.CartList;

public class CartListConfiguration : IEntityTypeConfiguration<Domain.Entities.Users.CartList>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Users.CartList> b)
    {
        b.HasOne(cl => cl.Product)
            .WithMany()
            .HasForeignKey(cl => cl.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne<User>()
            .WithMany(u => u.Cart)
            .HasForeignKey(cl => cl.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Property(cl => cl.Price).HasPrecision(18, 2);

        b.Property(cl => cl.AddedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();
    }
}