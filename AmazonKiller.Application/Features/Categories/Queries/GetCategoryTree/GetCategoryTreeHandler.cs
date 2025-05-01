using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.GetCategoryTree;

public class GetCategoryTreeHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<GetCategoryTreeQuery, List<CategoryTreeDto>>
{
    public async Task<List<CategoryTreeDto>> Handle(GetCategoryTreeQuery _, CancellationToken ct)
    {
        var tree = await repo.GetTreeAsync(ct);
        return mapper.Map<List<CategoryTreeDto>>(tree);
    }
}