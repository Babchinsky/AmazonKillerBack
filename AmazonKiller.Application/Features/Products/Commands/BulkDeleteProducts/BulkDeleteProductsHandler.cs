using AmazonKiller.Application.DTOs.Common;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;

public class BulkDeleteProductsHandler(IProductRepository repo)
    : IRequestHandler<BulkDeleteProductsCommand, BulkDeleteResultDto>
{
    public async Task<BulkDeleteResultDto> Handle(BulkDeleteProductsCommand cmd, CancellationToken ct)
    {
        var products = await repo.Queryable()
            .Where(p => cmd.Ids.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync(ct);

        var notFound = cmd.Ids.Except(products).ToList();

        await repo.BulkDeleteAsync(products, ct);

        return new BulkDeleteResultDto
        {
            DeletedCount = products.Count,
            NotFoundIds = notFound
        };
    }
}