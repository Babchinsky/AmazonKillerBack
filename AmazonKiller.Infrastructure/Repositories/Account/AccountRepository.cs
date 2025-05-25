using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class AccountRepository(AmazonDbContext db, IFileStorage fileStorage) : IAccountRepository
{
    public Task<User?> GetCurrentUserAsync(Guid userId, CancellationToken ct)
    {
        return db.Users.FindAsync([userId], ct).AsTask();
    }

    public Task<User?> GetCurrentUserWithTokensAsync(Guid userId, CancellationToken ct)
    {
        return db.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.Id == userId, ct);
    }

    public Task SaveChangesAsync(CancellationToken ct)
    {
        return db.SaveChangesAsync(ct);
    }

    public async Task DeleteUserAsync(User user, CancellationToken ct)
    {
        var photo = user.ImageUrl;
        db.RefreshTokens.RemoveRange(user.RefreshTokens);
        user.Status = UserStatus.Deleted;
        db.Users.Update(user);
        await db.SaveChangesAsync(ct);

        if (!string.IsNullOrWhiteSpace(photo))
            await fileStorage.DeleteAsync(photo, ct);
    }

    public Task RevokeRefreshTokensAsync(Guid userId, CancellationToken ct)
    {
        db.RefreshTokens.RemoveRange(db.RefreshTokens.Where(x => x.UserId == userId));
        return db.SaveChangesAsync(ct);
    }
}