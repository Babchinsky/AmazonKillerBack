using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdHandler(
    ICategoryRepository categories,
    IProductRepository products,
    IMapper mapper
) : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(GetCategoryByIdQuery request, CancellationToken ct)
    {
        var category = await categories.GetByIdAsync(request.Id, ct)
                       ?? throw new NotFoundException("Category not found");

        var productAttrs = await products.Queryable()
            .Where(p => p.CategoryId == request.Id)
            .Select(p => p.Attributes)
            .ToListAsync(ct);

        var filters = new Dictionary<string, List<string>>();
        foreach (var key in category.PropertyKeys)
        {
            var values = productAttrs
                .SelectMany(attrs => attrs)
                .Where(a => a.Key == key)
                .Select(a => a.Value)
                .Distinct()
                .ToList();

            if (values.Count > 0)
                filters[key] = values;
        }

        var dto = mapper.Map<CategoryDetailsDto>(category) with
        {
            Filters = filters
        };

        return dto;
    }
}