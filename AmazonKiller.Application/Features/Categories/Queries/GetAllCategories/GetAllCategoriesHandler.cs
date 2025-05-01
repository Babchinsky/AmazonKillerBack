using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery _, CancellationToken ct)
    {
        var categories = await repo.GetAllAsync(ct);
        return mapper.Map<List<CategoryDto>>(categories);
    }
}