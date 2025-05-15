using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.Configurations.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Orders.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Orders.Order> b)
    {
        b.Property(o => o.TotalPrice)
            .HasPrecision(18, 2);

        b.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.OwnsOne(o => o.Info, info =>
        {
            info.OwnsOne(i => i.Delivery, delivery => { delivery.OwnsOne(d => d.Address); });

            info.OwnsOne(i => i.Payment);
        });
    }
}