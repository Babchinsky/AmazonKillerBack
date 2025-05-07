using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class AuthService(AmazonDbContext db, IConfiguration cfg, IPasswordService passwordService) : IAuthService
{
    public async Task<AuthTokensDto> LoginAsync(LoginUserCommand cmd)
    {
        var user = await db.Users.SingleOrDefaultAsync(u => u.Email == cmd.Email);

        if (user is null || user.Status == UserStatus.Deleted ||
            !passwordService.VerifyPassword(cmd.Password, user.PasswordHash))
            throw new AppException("Bad credentials", 401);

        db.RefreshTokens.RemoveRange(db.RefreshTokens
            .Where(t => t.UserId == user.Id && t.DeviceId == cmd.DeviceId));

        await db.SaveChangesAsync();

        return await IssueTokensAsync(user, cmd.DeviceId, cmd.IpAddress, cmd.UserAgent);
    }

    private async Task<AuthTokensDto> IssueTokensAsync(User user, string deviceId, string ip, string ua)
    {
        var refresh = await GenerateRefreshTokenAsync(user, deviceId, ip, ua);
        return new AuthTokensDto(GenerateJwt(user), refresh);
    }

    public Task<string> GenerateJwtTokenAsync(User u)
    {
        return Task.FromResult(GenerateJwt(u));
    }

    public async Task<string> GenerateRefreshTokenAsync(User u, string deviceId, string ip, string ua)
    {
        var rt = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            UserId = u.Id,
            DeviceId = deviceId,
            IpAddress = ip,
            UserAgent = ua
        };
        db.RefreshTokens.Add(rt);
        await db.SaveChangesAsync();
        return rt.Token;
    }

    // -- helpers --------------------------------------------------
    private string GenerateJwt(User u)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            cfg["Jwt:Issuer"],
            cfg["Jwt:Audience"],
            [
                new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
                new Claim(ClaimTypes.Email, u.Email),
                new Claim(ClaimTypes.Role, u.Role.ToString())
            ],
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}