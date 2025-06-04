using AmazonKiller.Application.DTOs.Common;
using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.BulkDeleteCategories;

public class BulkDeleteCategoriesHandler(
    ICategoryRepository categoryRepo,
    IProductRepository productRepo,
    ICollectionRepository collectionRepo)
    : IRequestHandler<BulkDeleteCategoriesCommand, BulkDeleteResultDto>
{
    public async Task<BulkDeleteResultDto> Handle(BulkDeleteCategoriesCommand cmd, CancellationToken ct)
    {
        var allCategories = await categoryRepo.GetAllAsync(ct);

        var rootIds = cmd.Ids.Distinct().ToArray();
        var idsToDelete = new HashSet<Guid>(rootIds);

        foreach (var root in rootIds)
            CollectChildren(root);

        var foundIds = allCategories.Select(c => c.Id).ToHashSet();
        var notFoundIds = rootIds.Where(id => !foundIds.Contains(id)).ToList();
        var matchedIds = idsToDelete.Except(notFoundIds).ToList();

        // Delete products
        var productsToDelete = await productRepo.Queryable()
            .Where(p => matchedIds.Contains(p.CategoryId))
            .ToListAsync(ct);
        await productRepo.DeleteRangeAsync(productsToDelete, ct);

        // Delete collections
        var collectionsToDelete = await collectionRepo.Queryable()
            .Where(c => matchedIds.Contains(c.CategoryId))
            .ToListAsync(ct);
        await collectionRepo.DeleteRangeAsync(collectionsToDelete, ct);

        // Delete Categories
        var categoriesToDelete = allCategories
            .Where(c => matchedIds.Contains(c.Id))
            .ToList();
        await categoryRepo.DeleteRangeAsync(categoriesToDelete, ct);

        return new BulkDeleteResultDto
        {
            DeletedCount = matchedIds.Count,
            NotFoundIds = notFoundIds
        };

        void CollectChildren(Guid parentId)
        {
            foreach (var child in allCategories.Where(c => c.ParentId == parentId))
                if (idsToDelete.Add(child.Id))
                    CollectChildren(child.Id);
        }
    }
}