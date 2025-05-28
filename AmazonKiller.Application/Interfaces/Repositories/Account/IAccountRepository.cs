using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface IAccountRepository
{
    Task<User?> GetUserByIdAsync(Guid userId, CancellationToken ct = default);
    Task<User?> GetUserWithTokensByIdAsync(Guid userId, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
    Task DeleteUserAsync(User user, CancellationToken ct);
    Task RevokeRefreshTokensAsync(Guid userId, CancellationToken ct);

    Task ThrowIfDeletedAsync(Guid userId, CancellationToken ct = default);
    Task<Role> GetRoleAsync(Guid id, CancellationToken ct = default);
}