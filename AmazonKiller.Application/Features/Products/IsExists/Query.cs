using MediatR;

namespace AmazonKiller.Application.Features.Products.IsExists;

public record IsProductExistsQuery(Guid Id) : IRequest<bool>;