namespace AmazonKiller.Domain.Entities.Users;

public class EmailVerification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public string TempPasswordHash { get; set; } = string.Empty;
}