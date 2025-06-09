using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Auth;

public interface IEmailVerificationRepository
{
    Task<EmailVerification?> GetValidEntryAsync(string email, string code, CancellationToken ct);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken ct);
    Task DeleteAsync(EmailVerification entry, CancellationToken ct);
    Task<EmailVerification?> GetValidEntryByUserIdAsync(Guid userId, string code, CancellationToken ct);

    Task<string> CreateAndSaveCodeAsync(string email, VerificationType type, string? tempPasswordHash, Guid? userId,
        CancellationToken ct);

    Task MarkAsConfirmedAsync(string email, string code, CancellationToken ct);
}