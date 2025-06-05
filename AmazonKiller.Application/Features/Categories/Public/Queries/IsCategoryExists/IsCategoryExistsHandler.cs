using AmazonKiller.Application.Interfaces.Services.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.IsCategoryExists;

public class IsCategoryExistsHandler(
    ICategoryQueryService categoryQueryService
) : IRequestHandler<IsCategoryExistsQuery, bool>
{
    public async Task<bool> Handle(IsCategoryExistsQuery request, CancellationToken ct)
    {
        return await categoryQueryService.IsVisibleAsync(request.Id, ct);
    }
}