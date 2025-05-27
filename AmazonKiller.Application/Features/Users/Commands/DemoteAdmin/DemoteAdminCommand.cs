using MediatR;

namespace AmazonKiller.Application.Features.Users.Commands.DemoteAdmin;

public record DemoteAdminCommand(Guid UserId) : IRequest<Unit>;