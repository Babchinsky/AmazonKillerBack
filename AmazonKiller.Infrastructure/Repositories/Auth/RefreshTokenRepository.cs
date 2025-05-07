using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class RefreshTokenRepository(AmazonDbContext db) : IRefreshTokenRepository
{
    public async Task AddAsync(RefreshToken token, CancellationToken ct = default)
    {
        await db.RefreshTokens.AddAsync(token, ct);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default)
    {
        return await db.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token, ct);
    }

    public async Task<RefreshToken?> GetWithUserByTokenAsync(string token, CancellationToken ct = default)
    {
        return await db.RefreshTokens.Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == token, ct);
    }

    public async Task<IEnumerable<RefreshToken>> GetAllByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        return await db.RefreshTokens.Where(rt => rt.UserId == userId).ToListAsync(ct);
    }

    public Task DeleteAsync(RefreshToken token, CancellationToken ct = default)
    {
        db.RefreshTokens.Remove(token);
        return Task.CompletedTask;
    }

    public Task DeleteAllByDeviceAsync(Guid userId, string deviceId, CancellationToken ct = default)
    {
        var tokens = db.RefreshTokens.Where(rt => rt.UserId == userId && rt.DeviceId == deviceId);
        db.RefreshTokens.RemoveRange(tokens);
        return Task.CompletedTask;
    }

    public Task SaveAsync(CancellationToken ct = default)
    {
        return db.SaveChangesAsync(ct);
    }
}