using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.RegisterAdmin;

public class RegisterAdminHandler(
    IUserRepository userRepo,
    IAdminSecretValidator secretValidator,
    IAuthService authService)
    : IRequestHandler<RegisterAdminCommand, string>
{
    public async Task<string> Handle(RegisterAdminCommand cmd, CancellationToken ct)
    {
        if (!secretValidator.IsValid(cmd.Secret))
            throw new AppException("Invalid admin registration secret", 403);

        if (await userRepo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("User already exists");

        var admin = new User
        {
            Id = Guid.NewGuid(),
            Email = cmd.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(cmd.Password),
            FirstName = cmd.FirstName,
            LastName = cmd.LastName,
        };

        await userRepo.AddAdminAsync(admin, ct);
        return await authService.GenerateJwtTokenAsync(admin);
    }
}