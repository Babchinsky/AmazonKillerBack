using AmazonKiller.Application.Interfaces;
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