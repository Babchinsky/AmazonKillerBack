using MediatR;

namespace AmazonKiller.Application.Features.Users.Commands.MakeUserAdmin;

public record MakeUserAdminCommand(Guid UserId) : IRequest<Unit>;