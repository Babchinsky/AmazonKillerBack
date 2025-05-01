using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken ct)
    {
        var c = await repo.GetByIdAsync(request.Id, ct)
                ?? throw new NotFoundException("Category not found");

        c.Name = request.Name;
        c.Status = request.Status;
        c.ParentId = request.ParentId;

        await repo.UpdateAsync(c, ct);
        return mapper.Map<CategoryDto>(c);
    }
}