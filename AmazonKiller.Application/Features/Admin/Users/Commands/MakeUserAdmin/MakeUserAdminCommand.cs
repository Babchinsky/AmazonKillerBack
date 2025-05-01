using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Commands.MakeUserAdmin;

public record MakeUserAdminCommand(Guid UserId) : IRequest<Unit>;