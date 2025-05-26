using AmazonKiller.Application.DTOs.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.BulkRestoreUsers;

public record BulkRestoreUsersCommand(List<Guid> UserIds) : IRequest<BulkRestoreResultDto>;