using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.StartEmailChange;

public class StartEmailChangeHandler(
    IVerificationEmailSender verificationEmailSender,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo
) : IRequestHandler<StartEmailChangeCommand>
{
    public async Task Handle(StartEmailChangeCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId ?? throw new AppException("Unauthorized", 401);

        var user = await accountRepo.GetCurrentUserAsync(userId, ct)
                   ?? throw new AppException("User not found", 404);

        if (user.Email == cmd.NewEmail)
            throw new AppException("New email cannot be the same as the current email");

        await verificationEmailSender.CreateAndSendAsync(
            cmd.NewEmail,
            "Confirm your new email",
            VerificationType.EmailChange,
            null,
            userId,
            ct);
    }
}