using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class EmailVerificationRepository(AmazonDbContext db, IWebHostEnvironment env) : IEmailVerificationRepository
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

    public Task<EmailVerification?> GetValidEntryByUserIdAsync(Guid userId, string code, CancellationToken ct)
    {
        return db.EmailVerifications
            .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.Code == code &&
                    x.ExpiresAt > DateTime.UtcNow,
                ct);
    }

    public async Task<string> CreateCodeAsync(string email, string tempPasswordHash, CancellationToken ct)
    {
        var code = env.IsEnvironment("Testing") ? "123456" : GenerateRandomCode();

        var entry = new EmailVerification
        {
            Email = email,
            Code = code,
            TempPasswordHash = tempPasswordHash,
            ExpiresAt = DateTime.UtcNow.AddMinutes(15)
        };

        db.EmailVerifications.Add(entry);
        await db.SaveChangesAsync(ct);

        return code;
    }

    private static string GenerateRandomCode()
    {
        var rnd = new Random();
        return rnd.Next(100000, 999999).ToString();
    }
}