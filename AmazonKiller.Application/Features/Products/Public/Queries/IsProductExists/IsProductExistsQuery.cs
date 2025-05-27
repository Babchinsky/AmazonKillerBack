using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.IsProductExists;

public record IsProductExistsQuery(Guid Id) : IRequest<bool>;