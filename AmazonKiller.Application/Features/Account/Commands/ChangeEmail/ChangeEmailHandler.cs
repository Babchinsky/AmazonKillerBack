using AmazonKiller.Application.Interfaces;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ChangeEmail;

public class ChangeEmailHandler(ICurrentUserService currentUser, IAccountRepository repo)
    : IRequestHandler<ChangeEmailCommand, Unit>
{
    public async Task<Unit> Handle(ChangeEmailCommand cmd, CancellationToken ct)
    {
        var user = await repo.GetCurrentUserAsync(currentUser.UserId!.Value, ct);
        if (user is null)
            throw new AppException("User not found", 404);

        if (user.Email == cmd.Email)
            throw new AppException("New email cannot be the same as current");

        if (await repo.IsEmailTakenAsync(cmd.Email, user.Id, ct))
            throw new AppException("Email already taken", 409);

        user.Email = cmd.Email;
        await repo.SaveChangesAsync(ct);

        return Unit.Value;
    }
}