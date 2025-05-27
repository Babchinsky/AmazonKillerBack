using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class AccountRepository(AmazonDbContext db, IFileStorage fileStorage) : IAccountRepository
{
    private async Task<bool> IsUserDeletedAsync(Guid id, CancellationToken ct = default)
    {
        var user = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, ct);
        return user?.Status == UserStatus.Deleted;
    }

    public Task<User?> GetCurrentUserAsync(Guid userId, CancellationToken ct = default)
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

    public async Task ThrowIfDeletedAsync(Guid userId, CancellationToken ct = default)
    {
        var isDeleted = await IsUserDeletedAsync(userId, ct);
        if (isDeleted)
            throw new AppException("Your account has been deactivated.", StatusCodes.Status401Unauthorized);
    }

    public async Task<Role> GetRoleAsync(Guid id, CancellationToken ct = default)
    {
        return await db.Users
            .Where(u => u.Id == id)
            .Select(u => u.Role)
            .FirstOrDefaultAsync(ct);
    }
}