namespace AmazonKiller.Domain.Entities.Users;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public string Token { get; set; } = default!;
    public string DeviceId { get; set; } = default!;
    public string UserAgent { get; set; } = default!;
    public string IpAddress { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; } = false;

    public User User { get; set; } = default!;
}