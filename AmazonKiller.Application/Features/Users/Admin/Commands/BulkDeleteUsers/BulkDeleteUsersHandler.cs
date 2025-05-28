using AmazonKiller.Application.DTOs.Common;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Users.Admin.Commands.BulkDeleteUsers;

public class BulkDeleteUsersHandler(IAdminUserRepository repo)
    : IRequestHandler<BulkDeleteUsersCommand, BulkDeleteResultDto>
{
    public async Task<BulkDeleteResultDto> Handle(BulkDeleteUsersCommand request, CancellationToken ct)
    {
        var allUsers = await repo.Queryable()
            .Where(u => request.UserIds.Contains(u.Id))
            .ToListAsync(ct);

        var existingIds = allUsers.Select(u => u.Id).ToList();
        var missingIds = request.UserIds.Except(existingIds).ToList();

        await repo.MarkUsersDeletedAsync(existingIds, ct);

        return new BulkDeleteResultDto
        {
            DeletedCount = existingIds.Count,
            NotFoundIds = missingIds
        };
    }
}