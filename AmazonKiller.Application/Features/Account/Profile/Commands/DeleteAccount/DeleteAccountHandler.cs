using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.DeleteAccount;

public class DeleteAccountHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<DeleteAccountCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAccountCommand cmd, CancellationToken ct)
    {
        var user = await repo.GetCurrentUserWithTokensAsync(currentUser.UserId!.Value, ct);
        if (user is null)
            throw new AppException("User not found", 404);

        await repo.DeleteUserAsync(user, ct);
        return Unit.Value;
    }
}