using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangeName;

public class ChangeNameHandler(ICurrentUserService currentUserService, IAccountRepository accountRepo)
    : IRequestHandler<ChangeNameCommand>
{
    public async Task Handle(ChangeNameCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var user = await accountRepo.GetUserByIdAsync(currentUserId, ct)
                   ?? throw new NotFoundException("User not found");

        if (user.FirstName == cmd.FirstName && user.LastName == cmd.LastName)
            throw new AppException("New name cannot be the same as the current name");

        user.FirstName = cmd.FirstName;
        user.LastName = cmd.LastName;

        await accountRepo.SaveChangesAsync(ct);
    }
}