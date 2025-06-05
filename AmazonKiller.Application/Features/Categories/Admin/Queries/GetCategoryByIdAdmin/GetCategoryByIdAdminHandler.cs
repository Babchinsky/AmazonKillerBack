using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetCategoryByIdAdmin;

public class GetCategoryByIdAdminHandler(
    ICategoryQueryService categoryQueryService,
    ICategoryRepository categoryRepository,
    ICurrentUserService currentUser,
    IAccountRepository accountRepo,
    ICategoryFilterBuilder filterBuilder,
    IMapper mapper
) : IRequestHandler<GetCategoryByIdAdminQuery, CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(GetCategoryByIdAdminQuery request, CancellationToken ct)
    {
        var userId = currentUser.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var category = await categoryRepository.GetByIdAsync(request.Id, ct)
                       ?? throw new NotFoundException("Category not found");

        var descendantIds = await categoryQueryService.GetDescendantCategoryIdsAsync(request.Id, ct);
        descendantIds.Add(request.Id);

        var filters = await filterBuilder.BuildFiltersAsync(descendantIds, ct);

        var dto = mapper.Map<CategoryDetailsDto>(category) with
        {
            Filters = filters
        };

        return dto;
    }
}