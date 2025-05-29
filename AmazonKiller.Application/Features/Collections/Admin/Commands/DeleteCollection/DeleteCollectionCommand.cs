using MediatR;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.DeleteCollection;

public record DeleteCollectionCommand(Guid Id) : IRequest;