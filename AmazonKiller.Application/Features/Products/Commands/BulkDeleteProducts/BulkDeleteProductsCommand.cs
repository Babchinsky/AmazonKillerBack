using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;

public record BulkDeleteProductsCommand(List<Guid> Ids) : IRequest<Unit>;