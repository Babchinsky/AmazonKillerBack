using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
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

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(cmd.Password);

        var code = await repo.CreateCodeAsync(cmd.Email, hashedPassword, ct);

        await verificationEmailSender.SendVerificationCodeAsync(
            cmd.Email,
            "Confirm your registration",
            code
        );
    }
}