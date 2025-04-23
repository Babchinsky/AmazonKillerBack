using AmazonKiller.Application.Interfaces.Auth;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.StartEmailChange;

public class StartEmailChangeHandler(
    IEmailSender emailSender,
    IEmailVerificationRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<StartEmailChangeCommand>
{
    public async Task Handle(StartEmailChangeCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId ?? throw new AppException("Unauthorized", 401);

        var code = new Random().Next(100000, 999999).ToString();

        var request = new EmailVerification
        {
            Email = cmd.NewEmail,
            Code = code,
            ExpiresAt = DateTime.UtcNow.AddMinutes(10),
            UserId = userId
        };

        await repo.AddAsync(request, ct);

        var html = $"<h1>Email change code: {code}</h1>";
        await emailSender.SendEmailAsync(cmd.NewEmail, "Confirm your new email", html);
    }
}