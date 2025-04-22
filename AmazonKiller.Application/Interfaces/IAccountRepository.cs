using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces;

public interface IAccountRepository
{
    Task<User?> GetCurrentUserAsync(Guid userId, CancellationToken ct);
    Task<User?> GetCurrentUserWithTokensAsync(Guid userId, CancellationToken ct);
    Task<bool> IsEmailTakenAsync(string email, Guid currentUserId, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
    Task DeleteUserAsync(User user, CancellationToken ct);
    Task RevokeRefreshTokensAsync(Guid userId, CancellationToken ct);
}