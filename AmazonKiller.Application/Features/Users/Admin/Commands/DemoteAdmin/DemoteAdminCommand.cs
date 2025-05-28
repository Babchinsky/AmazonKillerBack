using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Commands.DemoteAdmin;

public record DemoteAdminCommand(Guid UserId) : IRequest<Unit>;