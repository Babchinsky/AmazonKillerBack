using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.IsExists;

public record IsProductExistsQuery(Guid Id) : IRequest<bool>;