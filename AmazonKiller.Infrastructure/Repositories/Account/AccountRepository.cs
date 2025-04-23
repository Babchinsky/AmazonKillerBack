using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class AccountRepository(AmazonDbContext db) : IAccountRepository
{
    public Task<User?> GetCurrentUserAsync(Guid userId, CancellationToken ct)
        => db.Users.FindAsync([userId], ct).AsTask();

    public Task<User?> GetCurrentUserWithTokensAsync(Guid userId, CancellationToken ct)
        => db.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.Id == userId, ct);

    public Task<bool> IsEmailTakenAsync(string email, Guid currentUserId, CancellationToken ct)
        => db.Users.AnyAsync(u => u.Email == email && u.Id != currentUserId, ct);

    public Task SaveChangesAsync(CancellationToken ct) => db.SaveChangesAsync(ct);

    public Task DeleteUserAsync(User user, CancellationToken ct)
    {
        db.RefreshTokens.RemoveRange(user.RefreshTokens);
        db.Users.Remove(user);
        return db.SaveChangesAsync(ct);
    }

    public Task RevokeRefreshTokensAsync(Guid userId, CancellationToken ct)
    {
        db.RefreshTokens.RemoveRange(db.RefreshTokens.Where(x => x.UserId == userId));
        return db.SaveChangesAsync(ct);
    }
}