using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Commands.MakeUserAdmin;

public class MakeUserAdminHandler(IAdminUserRepository repo, IAccountRepository accountRepo)
    : IRequestHandler<MakeUserAdminCommand, Unit>
{
    public async Task<Unit> Handle(MakeUserAdminCommand request, CancellationToken ct)
    {
        var user = await repo.GetByIdAsync(request.UserId, ct) ?? throw new NotFoundException("User not found");
        user.Role = Role.Admin;
        await repo.SaveChangesAsync(ct);
        await accountRepo.RevokeRefreshTokensAsync(user.Id, ct);
        return Unit.Value;
    }
}