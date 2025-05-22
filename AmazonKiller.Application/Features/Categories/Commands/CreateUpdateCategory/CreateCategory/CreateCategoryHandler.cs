using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateUpdateCategory.CreateCategory;

public class CreateCategoryHandler(
    ICategoryRepository repo,
    IFileStorage fileStorage,
    IMapper mapper) : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken ct)
    {
        if (request.ParentId is not null)
        {
            var exists = await repo.IsExistsAsync(request.ParentId.Value, ct);
            if (!exists)
                throw new AppException($"Parent category with ID {request.ParentId} not found");
        }

        string? imageUrl = null;
        if (request.Image != null)
        {
            await using var stream = request.Image.OpenReadStream();
            var ext = Path.GetExtension(request.Image.FileName);
            imageUrl = await fileStorage.SaveAsync(stream, ext, ct);
        }

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ParentId = request.ParentId,
            Description = request.Description,
            ImageUrl = imageUrl,
            IconName = request.ParentId == null ? request.IconName : null,
            PropertyKeys = request.ParentId != null ? request.PropertyKeys ?? [] : [],
            Status = request.Status
        };

        await repo.AddAsync(category, ct);
        return mapper.Map<CategoryDto>(category);
    }
}