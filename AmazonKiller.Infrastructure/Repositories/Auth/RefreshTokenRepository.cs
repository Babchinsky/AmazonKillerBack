using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class RefreshTokenRepository(AmazonDbContext db) : IRefreshTokenRepository
{
    public Task<RefreshToken?> GetWithUserByTokenAsync(string token, CancellationToken ct)
        => db.RefreshTokens.Include(t => t.User).SingleOrDefaultAsync(t => t.Token == token, ct);

    public Task RevokeAsync(RefreshToken token, CancellationToken ct)
    {
        db.RefreshTokens.Remove(token);
        return Task.CompletedTask;
    }

    public Task SaveAsync(CancellationToken ct) => db.SaveChangesAsync(ct);
}