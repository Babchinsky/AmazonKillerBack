using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Users;

public class Wishlist
{
    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public Guid ProductId { get; init; }
    public Product Product { get; init; } = null!;

    public DateTime AddedAt { get; init; }
}