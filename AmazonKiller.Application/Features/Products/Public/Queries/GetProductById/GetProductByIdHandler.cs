using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.GetProductById;

public class GetProductByIdHandler(
    IProductRepository productRepo,
    ICategoryQueryService categoryQueryService,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken ct)
    {
        var product = await productRepo.GetByIdAsync(request.Id, ct);
        if (product == null) return null;

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

        return visibleIds.Contains(product.CategoryId)
            ? mapper.Map<ProductDto>(product)
            : null;
    }
}