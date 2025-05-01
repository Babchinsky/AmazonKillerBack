using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.DemoteAdmin;

public record DemoteAdminCommand(Guid UserId) : IRequest<Unit>;