using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;

public static class CollectionFilterValidator
{
    public static async Task ValidateFiltersAsync(
        Guid categoryId,
        IReadOnlyCollection<CollectionFilterDto> filters,
        ICategoryRepository categories,
        IProductRepository products,
        CancellationToken ct)
    {
        var category = await categories.GetByIdAsync(categoryId, ct)
                       ?? throw new NotFoundException("Category not found.");

        var allowedKeys = category.PropertyKeys.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var wrongKey = filters.FirstOrDefault(f => !allowedKeys.Contains(f.Key));
        if (wrongKey is not null)
            throw new AppException($"Filter key '{wrongKey.Key}' is not allowed for this category.");

        var rawPairs = await products.Queryable()
            .Where(p => p.CategoryId == categoryId)
            .SelectMany(p => p.Attributes.Select(a => new { a.Key, a.Value }))
            .Distinct()
            .ToListAsync(ct);

        var attrHash = rawPairs.Select(p => (p.Key.ToLower(), p.Value.ToLower())).ToHashSet();

        var wrongValue = filters.FirstOrDefault(f =>
            !attrHash.Contains((f.Key.ToLower(), f.Value.ToLower())));

        if (wrongValue is not null)
            throw new AppException(
                $"Filter value '{wrongValue.Value}' for key '{wrongValue.Key}' " +
                "does not exist in products of this category.");
    }
}