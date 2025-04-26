using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.IsProductExists;

public record IsProductExistsQuery(Guid Id) : IRequest<bool>;