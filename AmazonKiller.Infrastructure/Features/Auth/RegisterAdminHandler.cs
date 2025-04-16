using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AmazonKiller.Application.Interfaces;

namespace AmazonKiller.Infrastructure.Features.Auth;

public class RegisterAdminHandler(AmazonDbContext db, IConfiguration config, IAuthService authService)
    : IRequestHandler<RegisterAdminCommand, string>
{
    public async Task<string> Handle(RegisterAdminCommand command, CancellationToken cancellationToken)
    {
        var expectedSecret = config["Admin:RegistrationSecret"];

        if (command.Secret != expectedSecret)
            throw new AppException("Invalid admin registration secret", 403);

        if (await db.Users.AnyAsync(u => u.Email == command.Email, cancellationToken))
            throw new AppException("User already exists", 400);

        var admin = new User
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Role = Role.Admin
        };

        db.Users.Add(admin);
        await db.SaveChangesAsync(cancellationToken);

        return await authService.GenerateJwtTokenAsync(admin);
    }
}