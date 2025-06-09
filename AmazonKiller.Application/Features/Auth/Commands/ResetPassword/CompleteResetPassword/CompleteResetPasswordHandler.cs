using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResetPassword.CompleteResetPassword;

public class CompleteResetPasswordHandler(
    IEmailVerificationRepository repo,
    IUserRepository userRepo,
    IPasswordService passwordService,
    IAuthService auth,
    ICurrentRequestContext context
) : IRequestHandler<CompleteResetPasswordCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(CompleteResetPasswordCommand cmd, CancellationToken ct)
    {
        var entry = await repo.GetValidEntryAsync(cmd.Email, cmd.Code, ct);
        if (entry is null || !entry.IsConfirmed)
            throw new AppException("Code not confirmed");

        var user = await userRepo.GetUserByEmailAsync(cmd.Email, ct)
                   ?? throw new AppException("User not found");

        if (passwordService.VerifyPassword(cmd.NewPassword, user.PasswordHash))
            throw new AppException("New password cannot be the same as the old password");

        user.PasswordHash = passwordService.HashPassword(cmd.NewPassword);
        await userRepo.SaveAsync(ct);
        await repo.DeleteAsync(entry, ct);

        var jwt = await auth.GenerateJwtTokenAsync(user);
        var refresh = await auth.GenerateRefreshTokenAsync(
            user,
            cmd.DeviceId,
            context.IpAddress,
            context.UserAgent);

        return new AuthTokensDto
        {
            AccessToken = jwt,
            RefreshToken = refresh
        };
    }
}