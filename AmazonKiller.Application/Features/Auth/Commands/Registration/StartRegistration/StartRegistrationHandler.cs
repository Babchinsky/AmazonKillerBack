using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
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
        var existingUser = await repo.GetUserByEmailAsync(cmd.Email, ct);

        if (existingUser is not null)
        {
            if (existingUser.Status == UserStatus.Deleted)
                throw new AppException(
                    "This account was previously deleted. Please contact support or try to restore it.");

            throw new AppException("Email is already taken");
        }

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