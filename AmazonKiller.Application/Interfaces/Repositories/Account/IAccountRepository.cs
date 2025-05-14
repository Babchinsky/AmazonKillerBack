using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface IAccountRepository
{
    Task<User?> GetCurrentUserAsync(Guid userId, CancellationToken ct);
    Task<User?> GetCurrentUserWithTokensAsync(Guid userId, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
    Task DeleteUserAsync(User user, CancellationToken ct);
    Task RevokeRefreshTokensAsync(Guid userId, CancellationToken ct);
}