using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.BulkRestoreUsers;

public record BulkRestoreUsersCommand(List<Guid> UserIds) : IRequest<Unit>;