using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Auth;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetWithUserByTokenAsync(string token, CancellationToken ct = default);

    Task DeleteAsync(RefreshToken token, CancellationToken ct = default);

    Task SaveAsync(CancellationToken ct = default);
}