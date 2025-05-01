using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.DemoteAdmin;

public class DemoteAdminHandler(IAdminUserRepository repo, IAccountRepository accountRepo)
    : IRequestHandler<DemoteAdminCommand, Unit>
{
    public async Task<Unit> Handle(DemoteAdminCommand request, CancellationToken ct)
    {
        var user = await repo.GetByIdAsync(request.UserId, ct) ?? throw new NotFoundException("User not found");
        user.Role = Role.Customer;
        await repo.SaveChangesAsync(ct);
        await accountRepo.RevokeRefreshTokensAsync(user.Id, ct);
        return Unit.Value;
    }
}