using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.IsExists;

public class IsProductExistsHandler(IProductRepository repo)
    : IRequestHandler<IsProductExistsQuery, bool>
{
    public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken cancellationToken)
    {
        return await repo.IsExistsAsync(request.Id);
    }
}