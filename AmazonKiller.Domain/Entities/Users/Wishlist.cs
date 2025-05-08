using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Users;

public class Wishlist
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public DateTime AddedAt { get; set; }
}