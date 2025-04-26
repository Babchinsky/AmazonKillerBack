using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeName;

public class ChangeNameHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<ChangeNameCommand>
{
    public async Task Handle(ChangeNameCommand cmd, CancellationToken ct)
    {
        var user = await repo.GetCurrentUserAsync(currentUser.UserId!.Value, ct);
        if (user is null)
            throw new AppException("User not found", 404);

        if (user.FirstName == cmd.FirstName && user.LastName == cmd.LastName)
            throw new AppException("New name cannot be the same as the current name");

        user.FirstName = cmd.FirstName;
        user.LastName = cmd.LastName;

        await repo.SaveChangesAsync(ct);
    }
}