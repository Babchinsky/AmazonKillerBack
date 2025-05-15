namespace AmazonKiller.Domain.Entities.Users;

public class RefreshToken
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; init; }
    public string Token { get; init; } = null!;
    public string DeviceId { get; init; } = null!;
    public string UserAgent { get; init; } = null!;
    public string IpAddress { get; init; } = null!;
    public DateTime ExpiresAt { get; init; }
    public bool IsRevoked { get; init; }

    public User User { get; init; } = null!;
}