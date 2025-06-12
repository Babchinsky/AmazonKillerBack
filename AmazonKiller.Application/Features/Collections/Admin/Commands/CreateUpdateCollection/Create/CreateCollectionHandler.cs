using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;
using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Create;

public class CreateCollectionHandler(
    ICollectionRepository collections,
    ICategoryRepository categories,
    IProductRepository products,
    IFileStorage files,
    IMapper mapper)
    : IRequestHandler<CreateCollectionCommand, CollectionDetailsDto>
{
    public async Task<CollectionDetailsDto> Handle(CreateCollectionCommand cmd, CancellationToken ct)
    {
        if (cmd.CategoryId == Guid.Empty)
            throw new AppException("CategoryId is required.");

        /* — validation — */
        await CollectionFilterValidator.ValidateFiltersAsync(
            cmd.CategoryId, cmd.ParsedFilters, categories, products, ct);

        /* — file upload — */
        string? img = null;
        if (cmd.Image is not null)
        {
            await using var s = cmd.Image.OpenReadStream();
            img = await files.SaveAsync(s, Path.GetExtension(cmd.Image.FileName), ct);
        }

        /* — create aggregate — */
        var entity = mapper.Map<Collection>(cmd);
        entity.Filters = mapper.Map<List<CollectionFilter>>(cmd.ParsedFilters);
        entity.ImageUrl = img;
        entity.IsActive = true;

        await collections.AddAsync(entity, ct);

        /* — fetch a fresh version with nav-props and return dto — */
        var saved = await collections.GetByIdAsync(entity.Id, ct);
        return mapper.Map<CollectionDetailsDto>(saved);
    }
}