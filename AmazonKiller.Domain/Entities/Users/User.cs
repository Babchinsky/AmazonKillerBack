using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Domain.Entities.Users;

public class User
{
    public Guid Id { get; set; }

    public string? ProfilePicUrl { get; set; }

    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required] [PasswordPropertyText] public string PasswordHash { get; set; } = string.Empty;

    [Required] public Role Role { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 1)]
    public string LastName { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Wishlist> WishlistsItems { get; set; } = new List<Wishlist>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}