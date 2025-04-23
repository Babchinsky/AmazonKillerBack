using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class EmailVerificationRepository(AmazonDbContext db) : IEmailVerificationRepository
{
    public Task AddAsync(EmailVerification entry, CancellationToken ct)
    {
        db.EmailVerifications.Add(entry);
        return db.SaveChangesAsync(ct);
    }

    public Task<EmailVerification?> GetValidEntryAsync(string email, string code, CancellationToken ct)
    {
        return db.EmailVerifications
            .FirstOrDefaultAsync(x =>
                x.Email == email && x.Code == code && x.ExpiresAt > DateTime.UtcNow, ct);
    }

    public Task<bool> IsEmailTakenAsync(string email, CancellationToken ct)
    {
        return db.Users.AnyAsync(u => u.Email == email, ct);
    }

    public Task DeleteAsync(EmailVerification entry, CancellationToken ct)
    {
        db.EmailVerifications.Remove(entry);
        return db.SaveChangesAsync(ct);
    }
}