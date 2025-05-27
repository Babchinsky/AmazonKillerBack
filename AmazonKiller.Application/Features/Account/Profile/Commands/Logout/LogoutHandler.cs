using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.Logout;

public class LogoutHandler(ICurrentUserService currentUserService, IAccountRepository accountRepo)
    : IRequestHandler<LogoutCommand, Unit>
{
    public async Task<Unit> Handle(LogoutCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        await accountRepo.RevokeRefreshTokensAsync(currentUserId, ct);
        return Unit.Value;
    }
}