using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangeName;

public record ChangeNameCommand(string FirstName, string LastName) : IRequest<Unit>, IRequest;