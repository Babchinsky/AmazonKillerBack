using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AmazonKiller.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly AmazonDbContext _db;
    private readonly IConfiguration  _cfg;
    public AuthService(AmazonDbContext db, IConfiguration cfg) { _db = db; _cfg = cfg; }

    public async Task<AuthTokensDto> RegisterAsync(RegisterUserCommand cmd)
    {
        if (await _db.Users.AnyAsync(u => u.Email == cmd.Email))
            throw new AppException("User exists", 400);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = cmd.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(cmd.Password),
            FirstName  = cmd.FirstName,
            LastName   = cmd.LastName,
            Role       = Role.Customer
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return await IssueTokensAsync(user);
    }

    public async Task<AuthTokensDto> LoginAsync(LoginUserCommand cmd)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == cmd.Email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(cmd.Password, user.PasswordHash))
            throw new AppException("Bad credentials", 401);

        _db.RefreshTokens.RemoveRange(_db.RefreshTokens.Where(t => t.UserId == user.Id));
        return await IssueTokensAsync(user);
    }

    private async Task<AuthTokensDto> IssueTokensAsync(User user)
    {
        var refresh = await GenerateRefreshTokenAsync(user);
        return new AuthTokensDto(GenerateJwt(user), refresh);
    }

    public Task<string> GenerateJwtTokenAsync(User u) => Task.FromResult(GenerateJwt(u));

    public async Task<string> GenerateRefreshTokenAsync(User u)
    {
        var rt = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            UserId = u.Id
        };
        _db.RefreshTokens.Add(rt);
        await _db.SaveChangesAsync();
        return rt.Token;
    }

    // -- helpers --------------------------------------------------
    private string GenerateJwt(User u)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _cfg["Jwt:Issuer"],
            _cfg["Jwt:Audience"],
            new[]
            {
                new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
                new Claim(ClaimTypes.Email, u.Email),
                new Claim(ClaimTypes.Role, u.Role.ToString())
            },
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}