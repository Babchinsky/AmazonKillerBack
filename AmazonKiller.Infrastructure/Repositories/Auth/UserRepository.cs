using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class UserRepository(AmazonDbContext db) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken ct)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
    }

    public async Task AddAdminAsync(User user, CancellationToken ct)
    {
        user.Role = Role.Admin;
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
    }

    public Task<bool> IsEmailTakenAsync(string email, CancellationToken ct)
        => db.Users.AnyAsync(u => u.Email == email, ct);
}