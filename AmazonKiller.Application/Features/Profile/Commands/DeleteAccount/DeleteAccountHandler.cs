using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.DeleteAccount;

public class DeleteAccountHandler(ICurrentUserService currentUserService, IAccountRepository accountRepo)
    : IRequestHandler<DeleteAccountCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAccountCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var user = await accountRepo.GetCurrentUserWithTokensAsync(currentUserId, ct);
        if (user is null)
            throw new AppException("User not found", 404);

        await accountRepo.DeleteUserAsync(user, ct);
        return Unit.Value;
    }
}