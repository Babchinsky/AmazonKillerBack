namespace AmazonKiller.Domain.Entities.Users;

public class EmailVerification
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Email { get; init; } = string.Empty;
    public string? Code { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public string? TempPasswordHash { get; init; } = string.Empty;
    public Guid? UserId { get; init; }
    public VerificationType Type { get; init; }
}