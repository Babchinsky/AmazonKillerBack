using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;
using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Update;

public class UpdateCollectionHandler(
    ICollectionRepository collections,
    ICategoryRepository categories,
    IProductRepository products,
    IFileStorage files,
    IMapper mapper)
    : IRequestHandler<UpdateCollectionCommand, CollectionDetailsDto>
{
    public async Task<CollectionDetailsDto> Handle(UpdateCollectionCommand cmd, CancellationToken ct)
    {
        var current = await collections.GetByIdAsync(cmd.Id, ct)
                      ?? throw new NotFoundException("Collection not found.");

        await CollectionFilterValidator.ValidateFiltersAsync(
            cmd.CategoryId, cmd.ParsedFilters, categories, products, ct);

        /* — image — */
        if (cmd.Image is not null)
        {
            if (!string.IsNullOrWhiteSpace(current.ImageUrl))
                await files.DeleteAsync(current.ImageUrl, ct);

            await using var s = cmd.Image.OpenReadStream();
            current.ImageUrl = await files.SaveAsync(s, Path.GetExtension(cmd.Image.FileName), ct);
        }

        /* — scalar fields — */
        current.Title = cmd.Title;
        current.CategoryId = cmd.CategoryId;
        current.MinPrice = cmd.MinPrice;
        current.MaxPrice = cmd.MaxPrice;

        /* — sync filters (owned entity) — */
        current.Filters.Clear();
        current.Filters.AddRange(
            cmd.ParsedFilters.Select(f => new CollectionFilter { Key = f.Key, Value = f.Value }));

        await collections.UpdateAsync(current, ct);

        var saved = await collections.GetByIdAsync(current.Id, ct);
        return mapper.Map<CollectionDetailsDto>(saved);
    }
}