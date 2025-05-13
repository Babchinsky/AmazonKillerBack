using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken ct)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ParentId = request.ParentId,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            IconName = request.ParentId == null ? request.IconName : null,
            PropertyKeys = request.ParentId != null ? request.PropertyKeys ?? [] : [],
            Status = request.Status
        };

        await repo.AddAsync(category, ct);
        return mapper.Map<CategoryDto>(category);
    }
}