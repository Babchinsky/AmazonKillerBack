using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Services;

public interface IVerificationEmailSender
{
    Task<string> CreateAndSendAsync(string email, string subject, VerificationType type, string? tempHash,
        CancellationToken ct);
}