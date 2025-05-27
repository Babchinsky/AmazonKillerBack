using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeEmail.ConfirmEmailChange;

public class ConfirmEmailChangeHandler(
    IEmailVerificationRepository repo,
    IUserRepository userRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo
) : IRequestHandler<ConfirmEmailChangeCommand, Unit>
{
    public async Task<Unit> Handle(ConfirmEmailChangeCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var entry = await repo.GetValidEntryByUserIdAsync(currentUserId, cmd.Code, ct);
        if (entry is null)
            throw new AppException("Invalid or expired code");

        await userRepo.ChangeEmailAsync(currentUserId, entry.Email, ct);
        await repo.DeleteAsync(entry, ct);

        return Unit.Value;
    }
}