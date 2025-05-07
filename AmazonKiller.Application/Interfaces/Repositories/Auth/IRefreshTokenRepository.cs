using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Auth;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token, CancellationToken ct = default);

    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default);

    Task<RefreshToken?> GetWithUserByTokenAsync(string token, CancellationToken ct = default);

    Task<IEnumerable<RefreshToken>> GetAllByUserIdAsync(Guid userId, CancellationToken ct = default);

    Task DeleteAsync(RefreshToken token, CancellationToken ct = default);

    Task DeleteAllByDeviceAsync(Guid userId, string deviceId, CancellationToken ct = default);

    Task SaveAsync(CancellationToken ct = default);
}