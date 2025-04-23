using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.Logout;

public class LogoutHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<LogoutCommand, Unit>
{
    public async Task<Unit> Handle(LogoutCommand cmd, CancellationToken ct)
    {
        var userId = currentUser.UserId;
        if (userId is null) return Unit.Value;

        await repo.RevokeRefreshTokensAsync(userId.Value, ct);
        return Unit.Value;
    }
}