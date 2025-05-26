using AmazonKiller.Application.DTOs.Common;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.BulkRestoreUsers;

public class BulkRestoreUsersHandler(IAdminUserRepository repo)
    : IRequestHandler<BulkRestoreUsersCommand, BulkRestoreResultDto>
{
    public async Task<BulkRestoreResultDto> Handle(BulkRestoreUsersCommand request, CancellationToken ct)
    {
        var existingUsers = await repo.Queryable()
            .Where(u => request.UserIds.Contains(u.Id))
            .ToListAsync(ct);

        var existingIds = existingUsers.Select(u => u.Id).ToList();
        var missingIds = request.UserIds.Except(existingIds).ToList();

        await repo.RestoreUsersAsync(existingIds, ct);

        return new BulkRestoreResultDto
        {
            RestoredCount = existingIds.Count,
            NotFoundIds = missingIds
        };
    }
}