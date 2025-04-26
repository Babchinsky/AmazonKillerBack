using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.StartRegistration;

public class StartRegistrationHandler(
    IVerificationEmailSender verificationEmailSender,
    IEmailVerificationRepository repo
) : IRequestHandler<StartRegistrationCommand>
{
    public async Task Handle(StartRegistrationCommand cmd, CancellationToken ct)
    {
        if (await repo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("Email is already taken");

        var code = new Random().Next(100000, 999999).ToString();
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(cmd.Password);

        var entry = new EmailVerification
        {
            Email = cmd.Email,
            Code = code,
            TempPasswordHash = hashedPassword,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10)
        };

        await repo.AddAsync(entry, ct);

        await verificationEmailSender.SendVerificationCodeAsync(cmd.Email, "Confirm your registration", code);
    }
}