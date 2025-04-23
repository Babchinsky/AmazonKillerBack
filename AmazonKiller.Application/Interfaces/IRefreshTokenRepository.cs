using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetWithUserByTokenAsync(string token, CancellationToken ct);
    Task RevokeAsync(RefreshToken token, CancellationToken ct);
    Task SaveAsync(CancellationToken ct);
}