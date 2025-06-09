using AmazonKiller.Domain.Entities.Common;

namespace AmazonKiller.Domain.Entities.Users;

public class EmailVerification : BaseEntity
{
    public string Email { get; init; } = string.Empty;
    public string? Code { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public string? TempPasswordHash { get; set; } = string.Empty;
    public Guid? UserId { get; init; }
    public VerificationType Type { get; init; }
    public bool IsConfirmed { get; set; } = false;
}