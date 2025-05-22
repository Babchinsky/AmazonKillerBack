using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.Logout;

public class LogoutHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<LogoutCommand, Unit>
{
    public async Task<Unit> Handle(LogoutCommand cmd, CancellationToken ct)
    {
        var userId = currentUser.UserId;

        await repo.RevokeRefreshTokensAsync(userId, ct);
        return Unit.Value;
    }
}