using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class RefreshTokenRepository(AmazonDbContext db) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetWithUserByTokenAsync(string token, CancellationToken ct = default)
    {
        return await db.RefreshTokens.Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == token, ct);
    }

    public Task DeleteAsync(RefreshToken token, CancellationToken ct = default)
    {
        db.RefreshTokens.Remove(token);
        return Task.CompletedTask;
    }

    public Task SaveAsync(CancellationToken ct = default)
    {
        return db.SaveChangesAsync(ct);
    }
}