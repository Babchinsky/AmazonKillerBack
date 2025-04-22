using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Features.Auth.Commands.Refresh;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Features.Auth;

public class RefreshTokenHandler(IAuthService auth, AmazonDbContext db)
    : IRequestHandler<RefreshTokenCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(RefreshTokenCommand req, CancellationToken ct)
    {
        var old = await db.RefreshTokens.Include(t => t.User)
            .SingleOrDefaultAsync(t => t.Token == req.RefreshToken, ct);

        if (old is null || old.ExpiresAt < DateTime.UtcNow)
            throw new AppException("Invalid/expired refresh token", 401);

        db.RefreshTokens.Remove(old);                       // revoke
        var newR = await auth.GenerateRefreshTokenAsync(old.User);

        return new AuthTokensDto(await auth.GenerateJwtTokenAsync(old.User), newR);
    }
}