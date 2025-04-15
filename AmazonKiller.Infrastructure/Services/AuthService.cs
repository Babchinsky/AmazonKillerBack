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
using System.Text;

namespace AmazonKiller.Infrastructure.Services;

public class AuthService(AmazonDbContext context, IConfiguration config) : IAuthService
{
    public async Task<string> RegisterAsync(RegisterUserCommand command)
    {
        if (await context.Users.AnyAsync(u => u.Email == command.Email))
            throw new Exception("User already exists");

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
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == command.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

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
}
