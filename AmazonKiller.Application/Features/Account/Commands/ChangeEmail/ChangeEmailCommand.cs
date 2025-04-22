using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ChangeEmail;

public record ChangeEmailCommand(string Email) : IRequest<Unit>;