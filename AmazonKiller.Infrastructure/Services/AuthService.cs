using AmazonKiller.Application.Features.Auth.Commands.Login;
using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AmazonKiller.Infrastructure.Exceptions;

namespace AmazonKiller.Infrastructure.Services;

public class AuthService(AmazonDbContext context, IConfiguration config) : IAuthService
{
    public async Task<string> RegisterAsync(RegisterUserCommand command)
    {
        if (await context.Users.AnyAsync(u => u.Email == command.Email))
            throw new AppException("User already exists", 400);


        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Role = Role.Customer
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return GenerateJwtToken(user);
    }

    public async Task<string> LoginAsync(LoginUserCommand command)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == command.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
            throw new AppException("Invalid credentials", 401);

        // Удаляем токены напрямую
        var oldTokens = await context.RefreshTokens
            .Where(t => t.UserId == user.Id)
            .ToListAsync();

        if (oldTokens.Count > 0)
            context.RefreshTokens.RemoveRange(oldTokens);

        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            UserId = user.Id
        };

        // Добавляем тоже напрямую
        context.RefreshTokens.Add(refreshToken);

        await context.SaveChangesAsync();

        return GenerateJwtToken(user);
    }
    
    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"] ?? string.Empty));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GenerateRefreshTokenAsync(User user)
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            UserId = user.Id
        };
        user.RefreshTokens.Add(refreshToken);
        await context.SaveChangesAsync();
        return refreshToken.Token;
    }

    public Task<string> GenerateJwtTokenAsync(User user)
    {
        return Task.FromResult(GenerateJwtToken(user));
    }
}