using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class UserRepository(AmazonDbContext db) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken ct)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
    }

    public Task<bool> IsEmailTakenAsync(string email, CancellationToken ct)
    {
        return db.Users.AnyAsync(u => u.Email == email, ct);
    }

    public async Task ChangeEmailAsync(Guid userId, string newEmail, CancellationToken ct)
    {
        var user = await db.Users.FindAsync([userId], ct);
        if (user is null)
            throw new AppException("User not found");

        user.Email = newEmail;
        await db.SaveChangesAsync(ct);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken ct)
    {
        return await db.Users.SingleOrDefaultAsync(u => u.Email == email, ct);
    }

    public async Task RemoveRefreshTokensForDeviceAsync(Guid userId, string deviceId, CancellationToken ct)
    {
        var tokens = db.RefreshTokens.Where(t => t.UserId == userId && t.DeviceId == deviceId);
        db.RefreshTokens.RemoveRange(tokens);
        await db.SaveChangesAsync(ct);
    }

    public async Task SaveAsync(CancellationToken ct)
    {
        await db.SaveChangesAsync(ct);
    }
}