namespace AmazonKiller.Domain.Entities.Users;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public string Token { get; set; } = null!;
    public string DeviceId { get; set; } = null!;
    public string UserAgent { get; set; } = null!;
    public string IpAddress { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }

    public User User { get; set; } = null!;
}