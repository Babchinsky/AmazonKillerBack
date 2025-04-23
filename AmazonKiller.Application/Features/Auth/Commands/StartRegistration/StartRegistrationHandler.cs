using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.StartRegistration;

public class StartRegistrationHandler(IEmailVerificationRepository repo, IEmailSender sender)
    : IRequestHandler<StartRegistrationCommand, Unit>
{
    public async Task<Unit> Handle(StartRegistrationCommand cmd, CancellationToken ct)
    {
        var code = Random.Shared.Next(100_000, 999_999).ToString();

        var entry = new EmailVerification
        {
            Email = cmd.Email,
            Code = code,
            ExpiresAt = DateTime.UtcNow.AddMinutes(15),
            IsUsed = false
        };

        await repo.AddAsync(entry, ct);

        var html = $"<h3>Your verification code is:</h3><h1>{code}</h1>";
        await sender.SendEmailAsync(cmd.Email, "Email Verification", html);

        return Unit.Value;
    }
}