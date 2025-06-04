using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryById;

public class GetCategoryByIdHandler(
    ICategoryQueryService categoryQueryService,
    IProductRepository productRepo,
    ICurrentUserService currentUser,
    IAccountRepository accountRepo,
    IMapper mapper
) : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(GetCategoryByIdQuery request, CancellationToken ct)
    {
        bool isAdmin;
        try
        {
            isAdmin = await accountRepo.GetRoleAsync(currentUser.UserId, ct) == Role.Admin;
        }
        catch (UnauthorizedAccessException)
        {
            isAdmin = false;
        }

        var category = await categoryQueryService.GetByIdIfVisibleAsync(request.Id, isAdmin, ct)
                       ?? throw new NotFoundException("Category not found");

        var descendantIds = await categoryQueryService.GetDescendantCategoryIdsAsync(request.Id, ct);
        descendantIds.Add(request.Id);

        var productAttrs = await productRepo.Queryable()
            .Where(p => descendantIds.Contains(p.CategoryId))
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