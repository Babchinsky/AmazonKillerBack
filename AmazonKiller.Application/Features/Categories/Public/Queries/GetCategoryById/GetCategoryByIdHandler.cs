using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryById;

public class GetCategoryByIdHandler(
    ICategoryQueryService categoryQueryService,
    ICategoryFilterBuilder filterBuilder,
    IMapper mapper
) : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(GetCategoryByIdQuery request, CancellationToken ct)
    {
        var category = await categoryQueryService.GetByIdIfVisibleAsync(request.Id, ct)
                       ?? throw new NotFoundException("Category not found");

        var descendantIds = await categoryQueryService.GetDescendantCategoryIdsAsync(request.Id, ct);
        descendantIds.Add(request.Id);

        var filters = await filterBuilder.BuildFiltersAsync(descendantIds, ct, category.ActivePropertyKeys);

        var dto = mapper.Map<CategoryDetailsDto>(category) with
        {
            Filters = filters
        };

        return dto;
    }
}