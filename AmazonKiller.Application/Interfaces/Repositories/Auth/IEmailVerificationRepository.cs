using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Auth;

public interface IEmailVerificationRepository
{
    Task AddAsync(EmailVerification entry, CancellationToken ct);
    Task<EmailVerification?> GetValidEntryAsync(string email, string code, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, CancellationToken ct);
    Task DeleteAsync(EmailVerification entry, CancellationToken ct);
    Task<EmailVerification?> GetValidEntryByUserIdAsync(Guid userId, string code, CancellationToken ct);
}