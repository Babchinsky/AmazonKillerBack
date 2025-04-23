using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories;

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
                x.Email == email && x.Code == code && !x.IsUsed && x.ExpiresAt > DateTime.UtcNow, ct);
    }

    public Task<bool> IsEmailTakenAsync(string email, CancellationToken ct)
    {
        return db.Users.AnyAsync(u => u.Email == email, ct);
    }

    public Task MarkAsUsedAsync(EmailVerification entry, CancellationToken ct)
    {
        entry.IsUsed = true;
        return db.SaveChangesAsync(ct);
    }
}
