using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.IsProductExists;

public class IsProductExistsHandler(IProductRepository repo)
    : IRequestHandler<IsProductExistsQuery, bool>
{
    public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken cancellationToken)
    {
        return await repo.IsExistsAsync(request.Id);
    }
}