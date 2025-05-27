using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.IsProductExists;

public class IsProductExistsHandler(
    IProductRepository productRepo,
    ICategoryQueryService categoryQueryService,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo
) : IRequestHandler<IsProductExistsQuery, bool>
{
    public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken ct)
    {
        var product = await productRepo.GetByIdAsync(request.Id, ct);
        if (product is null) return false;

        bool isAdmin;
        try
        {
            isAdmin = await accountRepo.GetRoleAsync(currentUserService.UserId, ct) == Role.Admin;
        }
        catch (UnauthorizedAccessException)
        {
            isAdmin = false;
        }

        var visibleCategories = await categoryQueryService.GetAllVisibleCategoriesAsync(isAdmin, ct);
        var visibleIds = visibleCategories.Select(c => c.Id).ToHashSet();
        return visibleIds.Contains(product.CategoryId);
    }
}