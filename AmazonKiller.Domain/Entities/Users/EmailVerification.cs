using AmazonKiller.Domain.Entities.Common;

namespace AmazonKiller.Domain.Entities.Users;

public class EmailVerification : BaseEntity
{
    public string Email { get; init; } = string.Empty;
    public string? Code { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public string? TempPasswordHash { get; init; } = string.Empty;
    public Guid? UserId { get; init; }
    public VerificationType Type { get; init; }
    public bool IsConfirmed { get; set; } = false;
}