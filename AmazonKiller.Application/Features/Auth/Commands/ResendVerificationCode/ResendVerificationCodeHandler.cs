using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResendVerificationCode;

public class ResendVerificationCodeHandler(
    IUserRepository userRepo,
    IVerificationEmailSender emailSender
) : IRequestHandler<ResendVerificationCodeCommand>
{
    public async Task Handle(ResendVerificationCodeCommand cmd, CancellationToken ct)
    {
        switch (cmd.Type)
        {
            case VerificationType.Registration:
            {
                if (await userRepo.IsEmailTakenAsync(cmd.Email, ct))
                    throw new AppException("Email already taken");

                await emailSender.CreateAndSendAsync(
                    cmd.Email,
                    "Confirm your registration",
                    VerificationType.Registration,
                    tempHash: null,
                    userId: null,
                    ct);
                break;
            }

            case VerificationType.PasswordReset:
            {
                var user = await userRepo.GetUserByEmailAsync(cmd.Email, ct)
                           ?? throw new AppException("User not found");

                if (user.Status == UserStatus.Deleted)
                    throw new AppException("User was deleted");

                await emailSender.CreateAndSendAsync(
                    cmd.Email,
                    "Reset your password",
                    VerificationType.PasswordReset,
                    tempHash: user.PasswordHash,
                    userId: user.Id,
                    ct);
                break;
            }

            case VerificationType.EmailChange:
            default:
                throw new AppException("Unsupported verification type");
        }
    }
}