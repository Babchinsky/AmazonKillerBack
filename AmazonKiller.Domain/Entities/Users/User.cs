using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Domain.Entities.Reviews;

namespace AmazonKiller.Domain.Entities.Users;

public class User : VersionedEntity
{
    public string? ImageUrl { get; init; }

    public string Email { get; set; } = string.Empty;
    public string? PasswordHash { get; set; } = string.Empty;

    public Role Role { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; init; }

    public ICollection<Review> Reviews { get; init; } = new List<Review>();
    public ICollection<Order> Orders { get; init; } = new List<Order>();
    public ICollection<CartList> Cart { get; init; } = new List<CartList>();
    public ICollection<Wishlist> Wishlists { get; init; } = new List<Wishlist>();
    public ICollection<RefreshToken> RefreshTokens { get; init; } = new List<RefreshToken>();
    public ICollection<ReviewLike> LikedReviews { get; init; } = new List<ReviewLike>();
}