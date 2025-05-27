using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Public.Queries.GetAllCategories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetAllCategoriesAdmin;

public class GetAllCategoriesAdminHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<GetAllCategoriesAdminQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetAllCategoriesAdminQuery _, CancellationToken ct)
    {
        var categories = await repo.GetAllAsync(ct);
        return mapper.Map<List<CategoryDto>>(categories);
    }
}