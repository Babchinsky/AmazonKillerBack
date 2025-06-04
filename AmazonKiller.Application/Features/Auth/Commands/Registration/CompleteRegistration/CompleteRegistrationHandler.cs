using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.Registration.CompleteRegistration;

public class CompleteRegistrationHandler(
    IEmailVerificationRepository repo,
    IUserRepository userRepo,
    IAuthService auth,
    ICurrentRequestContext context
) : IRequestHandler<CompleteRegistrationCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(CompleteRegistrationCommand cmd, CancellationToken ct)
    {
        var entry = await repo.GetValidEntryAsync(cmd.Email, cmd.Code, ct);
        if (entry is null || !entry.IsConfirmed)
            throw new AppException("Code not confirmed");

        if (await userRepo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("Email already registered");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = cmd.Email,
            PasswordHash = entry.TempPasswordHash ?? throw new AppException("Missing temp password"),
            Role = Role.Customer,
            FirstName = cmd.FirstName,
            LastName = cmd.LastName,
            Status = UserStatus.Active
        };

        await userRepo.AddAsync(user, ct);
        await repo.DeleteAsync(entry, ct); // удаляем после полной регистрации

        var jwt = await auth.GenerateJwtTokenAsync(user);
        var refresh = await auth.GenerateRefreshTokenAsync(
            user,
            cmd.DeviceId,
            context.IpAddress,
            context.UserAgent);

        return new AuthTokensDto
        {
            AccessToken = jwt,
            RefreshToken = refresh
        };
    }
}