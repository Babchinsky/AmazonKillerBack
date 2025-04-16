using AmazonKiller.Application.Features.Auth.Commands.Refresh;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Features.Auth;

public class RefreshTokenHandler(IAuthService authService, AmazonDbContext db)
    : IRequestHandler<RefreshTokenCommand, string>
{
    public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await db.Set<RefreshToken>()
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == request.RefreshToken, cancellationToken);

        if (token == null || token.ExpiresAt < DateTime.UtcNow)
            throw new Exception("Invalid or expired refresh token");

        return await authService.GenerateJwtTokenAsync(token.User);
    }
}