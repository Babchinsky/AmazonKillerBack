using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Admin.Users;

public class AdminUserRepository(AmazonDbContext db) : IAdminUserRepository
{
    private async Task UpdateUserStatusAsync(List<Guid> ids, UserStatus status, CancellationToken ct)
    {
        if (ids.Count == 0) return;
        var users = await db.Users.Where(u => ids.Contains(u.Id)).ToListAsync(ct);
        foreach (var u in users) u.Status = status;
        await db.SaveChangesAsync(ct);
    }

    public Task<User?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
    }

    public IQueryable<User> Queryable()
    {
        return db.Users.AsNoTracking();
    }

    public Task SaveChangesAsync(CancellationToken ct)
    {
        return db.SaveChangesAsync(ct);
    }

    public async Task MarkUsersDeletedAsync(List<Guid> ids, CancellationToken ct)
    {
        if (ids.Count == 0) return;

        var users = await db.Users.Where(u => ids.Contains(u.Id)).ToListAsync(ct);
        foreach (var user in users)
            user.Status = UserStatus.Deleted;

        // Remove refresh tokens
        var tokens = await db.RefreshTokens
            .Where(rt => ids.Contains(rt.UserId))
            .ToListAsync(ct);
        db.RefreshTokens.RemoveRange(tokens);

        await db.SaveChangesAsync(ct);
    }

    public Task RestoreUsersAsync(List<Guid> ids, CancellationToken ct)
    {
        return UpdateUserStatusAsync(ids, UserStatus.Active, ct);
    }
}