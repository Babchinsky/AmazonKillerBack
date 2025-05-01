using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken ct)
    {
        var category = await repo.GetByIdAsync(request.Id, ct)
                       ?? throw new NotFoundException("Category not found");
        return mapper.Map<CategoryDto>(category);
    }
}