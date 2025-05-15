using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.StartRegistration;

public class StartRegistrationHandler(
    IVerificationEmailSender verificationEmailSender,
    IPasswordService passwordService,
    IEmailVerificationRepository repo
) : IRequestHandler<StartRegistrationCommand>
{
    public async Task Handle(StartRegistrationCommand cmd, CancellationToken ct)
    {
        if (await repo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("Email is already taken");

        var hashedPassword = passwordService.HashPassword(cmd.Password);

        await verificationEmailSender.CreateAndSendAsync(
            cmd.Email,
            "Confirm your registration",
            VerificationType.Registration,
            hashedPassword,
            null,
            ct);
    }
}