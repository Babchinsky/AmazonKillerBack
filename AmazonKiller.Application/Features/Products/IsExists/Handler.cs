using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.IsExists;

public class IsProductExistsHandler(IProductRepository repo)
    : IRequestHandler<IsProductExistsQuery, bool>
{
    public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken cancellationToken)
    {
        return await repo.IsExistsAsync(request.Id);
    }
}