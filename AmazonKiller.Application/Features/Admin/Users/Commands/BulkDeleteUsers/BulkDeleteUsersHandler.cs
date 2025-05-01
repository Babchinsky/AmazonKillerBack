using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.BulkDeleteUsers;

public class BulkDeleteUsersHandler(IAdminUserRepository repo) : IRequestHandler<BulkDeleteUsersCommand, Unit>
{
    public async Task<Unit> Handle(BulkDeleteUsersCommand request, CancellationToken ct)
    {
        var users = await repo.GetUsersByIdsAsync(request.UserIds, ct);

        var notFound = request.UserIds.Except(users.Select(u => u.Id)).ToList();
        if (notFound.Count != 0)
            throw new NotFoundException($"Users not found: {string.Join(", ", notFound)}");

        await repo.MarkUsersDeletedAsync(request.UserIds, ct);
        return Unit.Value;
    }
}