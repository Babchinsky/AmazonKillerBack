using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AmazonKiller.Infrastructure.Repositories.Auth;

public class EmailVerificationRepository(AmazonDbContext db, IConfiguration config) : IEmailVerificationRepository
{
    private readonly bool _useFixedCode = config.GetValue<bool>("Verification:UseFixedCode");
    private readonly string? _fixedCode = config.GetValue<string>("Verification:FixedCodeValue");

    private async Task DeleteByEmailAndTypeAsync(string email, VerificationType type, CancellationToken ct)
    {
        var old = db.EmailVerifications
            .Where(ev => ev.Email == email && ev.Type == type);

        db.EmailVerifications.RemoveRange(old);
        await db.SaveChangesAsync(ct);
    }

    private static string GenerateRandomCode()
    {
        var rnd = new Random();
        return rnd.Next(100000, 999999).ToString();
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

    public async Task<string> CreateAndSaveCodeAsync(
        string email,
        VerificationType type,
        string? tempPasswordHash,
        CancellationToken ct)
    {
        await DeleteByEmailAndTypeAsync(email, type, ct);

        var code = _useFixedCode ? _fixedCode ?? VerificationDefaults.DefaultFixedCode : GenerateRandomCode();

        var entry = new EmailVerification
        {
            Email = email,
            Code = code,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10),
            TempPasswordHash = tempPasswordHash,
            Type = type
        };

        db.EmailVerifications.Add(entry);
        await db.SaveChangesAsync(ct);

        return code;
    }
}