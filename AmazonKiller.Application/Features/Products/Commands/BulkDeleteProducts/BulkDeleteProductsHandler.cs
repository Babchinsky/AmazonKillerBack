using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;

public class BulkDeleteProductsHandler(IProductRepository repo)
    : IRequestHandler<BulkDeleteProductsCommand, Unit>
{
    public async Task<Unit> Handle(BulkDeleteProductsCommand cmd, CancellationToken ct)
    {
        await repo.BulkSoftDeleteAsync(cmd.Ids, ct);
        return Unit.Value;
    }
}