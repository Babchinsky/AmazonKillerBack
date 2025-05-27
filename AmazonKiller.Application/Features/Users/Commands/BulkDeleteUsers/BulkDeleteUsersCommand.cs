using AmazonKiller.Application.DTOs.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Commands.BulkDeleteUsers;

public record BulkDeleteUsersCommand(List<Guid> UserIds) : IRequest<BulkDeleteResultDto>;