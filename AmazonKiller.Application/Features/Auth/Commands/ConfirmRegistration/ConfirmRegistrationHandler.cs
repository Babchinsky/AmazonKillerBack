using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public class ConfirmRegistrationHandler(
    IEmailVerificationRepository repo,
    IUserRepository userRepo,
    IAuthService auth,
    ICurrentRequestContext context)
    : IRequestHandler<ConfirmRegistrationCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(ConfirmRegistrationCommand cmd, CancellationToken ct)
    {
        var entry = await repo.GetValidEntryAsync(cmd.Email, cmd.Code, ct);
        if (entry is null)
            throw new AppException("Invalid or expired code");

        if (await repo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("Email already in use");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = cmd.Email,
            PasswordHash = entry.TempPasswordHash,
            Role = Role.Customer
        };

        await userRepo.AddAsync(user, ct);
        await repo.DeleteAsync(entry, ct);

        var jwt = await auth.GenerateJwtTokenAsync(user);
        var refresh = await auth.GenerateRefreshTokenAsync(
            user,
            cmd.DeviceId,
            context.IpAddress,
            context.UserAgent);

        return new AuthTokensDto(jwt, refresh);
    }
}