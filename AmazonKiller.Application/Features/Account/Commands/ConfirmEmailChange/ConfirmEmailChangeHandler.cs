using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Auth;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ConfirmEmailChange;

public class ConfirmEmailChangeHandler(
    IEmailVerificationRepository repo,
    IUserRepository userRepo,
    ICurrentUserService currentUserService
) : IRequestHandler<ConfirmEmailChangeCommand, Unit>
{
    public async Task<Unit> Handle(ConfirmEmailChangeCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId ?? throw new AppException("Unauthorized", 401);

        var entry = await repo.GetValidEntryByUserIdAsync(userId, cmd.Code, ct);
        if (entry is null)
            throw new AppException("Invalid or expired code");

        await userRepo.ChangeEmailAsync(userId, entry.Email, ct);
        await repo.DeleteAsync(entry, ct);

        return Unit.Value;
    }
}