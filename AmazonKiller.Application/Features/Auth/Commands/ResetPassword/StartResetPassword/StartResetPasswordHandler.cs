using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.StartResetPassword;

public class StartResetPasswordHandler(
    IUserRepository userRepo,
    IVerificationEmailSender emailSender
) : IRequestHandler<StartResetPasswordCommand>
{
    public async Task Handle(StartResetPasswordCommand cmd, CancellationToken ct)
    {
        var user = await userRepo.GetUserByEmailAsync(cmd.Email, ct);
        if (user is null || user.Status == UserStatus.Deleted)
            throw new AppException("No user with such email");

        // генерируем временный hash текущего пароля, чтобы пройти валидацию позже
        var tempHash = user.PasswordHash;

        await emailSender.CreateAndSendAsync(
            cmd.Email,
            "Reset your password",
            VerificationType.PasswordReset,
            tempHash: tempHash,
            userId: user.Id,
            ct);
    }
}