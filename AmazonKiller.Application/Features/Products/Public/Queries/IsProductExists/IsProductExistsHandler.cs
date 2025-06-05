using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.IsProductExists;

public class IsProductExistsHandler(
    IProductRepository productRepo,
    ICategoryQueryService categoryQueryService
) : IRequestHandler<IsProductExistsQuery, bool>
{
    public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken ct)
    {
        var product = await productRepo.GetByIdAsync(request.Id, ct);
        if (product is null) return false;

        var visibleCategories = await categoryQueryService.GetAllVisibleCategoriesAsync(ct);
        var visibleIds = visibleCategories.Select(c => c.Id).ToHashSet();
        return visibleIds.Contains(product.CategoryId);
    }
}