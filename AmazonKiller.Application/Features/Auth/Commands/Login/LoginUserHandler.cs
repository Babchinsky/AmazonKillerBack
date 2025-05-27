using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Login;

public class LoginUserHandler(
    IUserRepository userRepo,
    IAuthService authService,
    IPasswordService passwordService,
    ICurrentRequestContext context
) : IRequestHandler<LoginUserCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(LoginUserCommand cmd, CancellationToken ct)
    {
        var user = await userRepo.GetUserByEmailAsync(cmd.Email, ct);

        if (user is null || user.Status == UserStatus.Deleted ||
            !passwordService.VerifyPassword(cmd.Password, user.PasswordHash))
            throw new AppException("Bad credentials", 401);

        await userRepo.RemoveRefreshTokensForDeviceAsync(user.Id, cmd.DeviceId, ct);

        var refresh = await authService.GenerateRefreshTokenAsync(
            user,
            cmd.DeviceId,
            context.IpAddress,
            context.UserAgent);

        var jwt = await authService.GenerateJwtTokenAsync(user);

        return new AuthTokensDto
        {
            AccessToken = jwt,
            RefreshToken = refresh
        };
    }
}