using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken ct)
    {
        if (request.ParentId is not null)
        {
            var exists = await repo.IsExistsAsync(request.ParentId.Value, ct);
            if (!exists)
                throw new AppException(
                    $"Parent category with ID {request.ParentId} not found");
        }

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