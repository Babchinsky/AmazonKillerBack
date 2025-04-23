using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.StartRegistration;

public class StartRegistrationHandler(IEmailSender sender, IEmailVerificationRepository repo)
    : IRequestHandler<StartRegistrationCommand>
{
    public async Task Handle(StartRegistrationCommand cmd, CancellationToken ct)
    {
        if (await repo.IsEmailTakenAsync(cmd.Email, ct))
            throw new AppException("Email is already taken");

        var code = new Random().Next(100000, 999999).ToString();
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(cmd.Password);

        var entry = new EmailVerification
        {
            Email = cmd.Email,
            Code = code,
            TempPasswordHash = hashedPassword,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10),
        };

        await repo.AddAsync(entry, ct);

        var html = $"<h1>Код подтверждения: {code}</h1>";
        await sender.SendEmailAsync(cmd.Email, "Код подтверждения регистрации", html);
    }
}