using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Refresh;

public class RefreshTokenHandler(
    IAuthService auth,
    IRefreshTokenRepository refreshRepo)
    : IRequestHandler<RefreshTokenCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(RefreshTokenCommand req, CancellationToken ct)
    {
        var old = await refreshRepo.GetWithUserByTokenAsync(req.RefreshToken, ct);

        if (old is null || old.ExpiresAt < DateTime.UtcNow)
            throw new AppException("Invalid/expired refresh token", 401);

        await refreshRepo.DeleteAsync(old, ct);
        await refreshRepo.SaveAsync(ct);

        var newToken = await auth.GenerateRefreshTokenAsync(
            old.User,
            req.DeviceId,
            req.IpAddress,
            req.UserAgent);
        return new AuthTokensDto(await auth.GenerateJwtTokenAsync(old.User), newToken);
    }
}