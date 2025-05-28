using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Orders;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; init; }

    public Guid ProductId { get; init; }

    public Product Product { get; init; } = null!;

    public decimal Price { get; init; }

    public int Quantity { get; init; }

    public DateTime OrderedAt { get; init; }
}