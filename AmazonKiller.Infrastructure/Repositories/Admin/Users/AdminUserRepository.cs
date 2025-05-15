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

    public Task<List<User>> GetUsersByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct)
    {
        return db.Users.Where(u => ids.Contains(u.Id)).ToListAsync(ct);
    }

    public IQueryable<User> Queryable()
    {
        return db.Users.AsNoTracking();
    }

    public Task SaveChangesAsync(CancellationToken ct)
    {
        return db.SaveChangesAsync(ct);
    }

    public Task MarkUsersDeletedAsync(List<Guid> ids, CancellationToken ct)
    {
        return UpdateUserStatusAsync(ids, UserStatus.Deleted, ct);
    }

    public async Task DeleteUsersAsync(IEnumerable<User> users, CancellationToken ct)
    {
        db.Users.RemoveRange(users);
        await db.SaveChangesAsync(ct);
    }

    public Task RestoreUsersAsync(List<Guid> ids, CancellationToken ct)
    {
        return UpdateUserStatusAsync(ids, UserStatus.Active, ct);
    }
}