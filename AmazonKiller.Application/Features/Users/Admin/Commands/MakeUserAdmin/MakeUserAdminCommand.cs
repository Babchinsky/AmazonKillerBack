using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Commands.MakeUserAdmin;

public record MakeUserAdminCommand(Guid UserId) : IRequest<Unit>;