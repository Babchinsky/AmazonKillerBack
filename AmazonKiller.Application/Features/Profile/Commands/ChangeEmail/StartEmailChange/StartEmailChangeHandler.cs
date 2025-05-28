using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeEmail.StartEmailChange;

public class StartEmailChangeHandler(
    IVerificationEmailSender verificationEmailSender,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo
) : IRequestHandler<StartEmailChangeCommand>
{
    public async Task Handle(StartEmailChangeCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var user = await accountRepo.GetUserByIdAsync(currentUserId, ct)
                   ?? throw new AppException("User not found", 404);

        if (user.Email == cmd.NewEmail)
            throw new AppException("New email cannot be the same as the current email");

        await verificationEmailSender.CreateAndSendAsync(
            cmd.NewEmail,
            "Confirm your new email",
            VerificationType.EmailChange,
            null,
            currentUserId,
            ct);
    }
}