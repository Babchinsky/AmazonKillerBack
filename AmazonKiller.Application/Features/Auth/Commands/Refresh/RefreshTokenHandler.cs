using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Refresh;

public class RefreshTokenHandler(
    IAuthService auth,
    IRefreshTokenRepository refreshRepo,
    ICurrentRequestContext context)
    : IRequestHandler<RefreshTokenCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(RefreshTokenCommand req, CancellationToken ct)
    {
        var old = await refreshRepo.GetWithUserByTokenAsync(req.RefreshToken, ct);

        if (old is null || old.ExpiresAt < DateTime.UtcNow)
            throw new AppException("Invalid or expired refresh token", 401);

        await refreshRepo.DeleteAsync(old, ct);
        await refreshRepo.SaveAsync(ct);

        var newToken = await auth.GenerateRefreshTokenAsync(
            old.User,
            req.DeviceId,
            context.IpAddress,
            context.UserAgent);

        var jwt = await auth.GenerateJwtTokenAsync(old.User);
        return new AuthTokensDto
        {
            AccessToken = jwt,
            RefreshToken = newToken
        };
    }
}