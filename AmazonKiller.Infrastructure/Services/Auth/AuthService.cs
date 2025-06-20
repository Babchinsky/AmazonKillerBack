﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Application.Options;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AmazonKiller.Infrastructure.Services.Auth;

public class AuthService(
    AmazonDbContext db,
    IOptions<JwtOptions> jwtOptionsAccessor
) : IAuthService
{
    private readonly JwtOptions _jwt = jwtOptionsAccessor.Value;

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

    private string GenerateJwt(User u)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, u.Id.ToString()),
            new(ClaimTypes.Role, u.Role.ToString())
        };

        var token = new JwtSecurityToken(
            _jwt.Issuer,
            _jwt.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}