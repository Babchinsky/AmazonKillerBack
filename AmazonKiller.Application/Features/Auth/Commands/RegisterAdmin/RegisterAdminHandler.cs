using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.RegisterAdmin;

public class RegisterAdminHandler(
    IUserRepository userRepo,
    IAdminSecretValidator secretValidator,
    IPasswordService passwordService,
    IAuthService authService,
    ICurrentRequestContext context
) : IRequestHandler<RegisterAdminCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(RegisterAdminCommand cmd, CancellationToken ct)
    {
        if (!secretValidator.IsValid(cmd.Secret))
            throw new AppException("Invalid admin registration secret", 403);

        if (await userRepo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("User already exists");

        var admin = new User
        {
            Id = Guid.NewGuid(),
            Email = cmd.Email,
            PasswordHash = passwordService.HashPassword(cmd.Password),
            FirstName = cmd.FirstName,
            LastName = cmd.LastName,
            Role = Role.Admin
        };

        await userRepo.AddAsync(admin, ct);

        var refresh = await authService.GenerateRefreshTokenAsync(
            admin,
            cmd.DeviceId,
            context.IpAddress,
            context.UserAgent);

        var jwt = await authService.GenerateJwtTokenAsync(admin);

        return new AuthTokensDto
        {
            AccessToken = jwt,
            RefreshToken = refresh
        };
    }
}