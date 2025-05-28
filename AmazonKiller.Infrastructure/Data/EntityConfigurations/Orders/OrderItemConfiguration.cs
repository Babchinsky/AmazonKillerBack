using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Infrastructure.Common.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Orders;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> b)
    {
        b.ToTable(tb => { tb.HasCheckConstraint("CK_OrderItem_Quantity_Positive", "[Quantity] > 0"); });

        b.Property(oi => oi.Price)
            .UseMoneyPrecision();

        b.Property(oi => oi.Quantity)
            .IsRequired();

        b.Property(oi => oi.OrderedAt)
            .IsRequired();
    }
}