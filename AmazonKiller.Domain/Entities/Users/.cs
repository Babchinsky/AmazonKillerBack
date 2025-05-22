using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Domain.Entities.Users;

public class User
{
    public Guid Id { get; init; }

    public string? ProfilePicUrl { get; init; }

    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required] [PasswordPropertyText] public string? PasswordHash { get; set; } = string.Empty;

    [Required] public Role Role { get; set; }

    [Required] public UserStatus Status { get; set; } = UserStatus.Active;

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>UTC-время создания записи.</summary>
    public DateTime CreatedAt { get; init; }

    // навигационные коллекции
    public ICollection<Order> Orders { get; init; } = new List<Order>();
    public ICollection<CartList> Cart { get; init; } = new List<CartList>();
    public ICollection<Wishlist> Wishlists { get; init; } = new List<Wishlist>();
    public ICollection<RefreshToken> RefreshTokens { get; init; } = new List<RefreshToken>();
}