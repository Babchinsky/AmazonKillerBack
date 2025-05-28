using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Users;

public class CartList : BaseEntity
{
    public Guid UserId { get; init; }
    public Guid ProductId { get; init; }

    public Product Product { get; init; } = null!;

    public int Quantity { get; set; }
    public decimal Price { get; init; }

    public DateTime AddedAt { get; init; }
}