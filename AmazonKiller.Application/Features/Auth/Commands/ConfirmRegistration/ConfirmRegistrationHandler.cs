using AmazonKiller.Application.DTOs.Auth;
using AmazonKiller.Application.Features.Auth.Commands.Register;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ConfirmRegistration;

public class ConfirmRegistrationHandler(
    IEmailVerificationRepository repo,
    IAuthService auth)
    : IRequestHandler<ConfirmRegistrationCommand, AuthTokensDto>
{
    public async Task<AuthTokensDto> Handle(ConfirmRegistrationCommand cmd, CancellationToken ct)
    {
        var entry = await repo.GetValidEntryAsync(cmd.Email, cmd.Code, ct);
        if (entry is null)
            throw new AppException("Invalid or expired code");

        if (await repo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("Email already in use");

        var register = new RegisterUserCommand(
            cmd.Email,
            entry.TempPasswordHash, 
            cmd.FirstName,
            cmd.LastName
        );

        var tokens = await auth.RegisterAsync(register, isPasswordHashed: true);

        await repo.MarkAsUsedAsync(entry, ct);
        return tokens;
    }
}