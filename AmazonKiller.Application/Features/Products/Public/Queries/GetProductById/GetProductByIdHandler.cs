using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.GetProductById;

public class GetProductByIdHandler(
    IProductRepository productRepo,
    ICategoryQueryService categoryQueryService,
    IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken ct)
    {
        var product = await productRepo.GetByIdAsync(request.Id, ct);
        if (product == null)
            throw new NotFoundException("Product not found");

        var visibleCategories = await categoryQueryService.GetAllVisibleCategoriesAsync(ct);
        var visibleIds = visibleCategories.Select(c => c.Id).ToHashSet();

        if (!visibleIds.Contains(product.CategoryId))
            throw new NotFoundException("Product is not accessible");

        return mapper.Map<ProductDto>(product);
    }
}