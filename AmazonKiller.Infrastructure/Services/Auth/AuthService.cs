using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class AuthService(AmazonDbContext db, IConfiguration cfg) : IAuthService
{
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

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, u.Id.ToString()),
            new(ClaimTypes.Email, u.Email),
            new(ClaimTypes.Role, u.Role.ToString()),
            new("status", u.Status.ToString()) // 👈 добавляем статус
        };

        var token = new JwtSecurityToken(
            cfg["Jwt:Issuer"],
            cfg["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}