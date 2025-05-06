using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.IsCategoryExists;

public class IsCategoryExistsHandler(ICategoryRepository repo)
    : IRequestHandler<IsCategoryExistsQuery, bool>
{
    public Task<bool> Handle(IsCategoryExistsQuery request, CancellationToken ct)
    {
        return repo.IsExistsAsync(request.Id, ct);
    }
}