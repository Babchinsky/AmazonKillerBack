using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.BulkDeleteCategories;

public class BulkDeleteCategoriesHandler(ICategoryRepository repo)
    : IRequestHandler<BulkDeleteCategoriesCommand>
{
    public async Task Handle(BulkDeleteCategoriesCommand cmd, CancellationToken ct)
    {
        await repo.BulkHardDeleteAsync(cmd.Ids, ct);
    }
}