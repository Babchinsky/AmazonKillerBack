using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.UpdateProduct;

public class UpdateProductHandler(
    IProductRepository repo,
    IPropertyKeyUpdater keyUpdater,
    IMapper mapper,
    IFileStorage files)
    : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand cmd, CancellationToken ct)
    {
        var product = await repo.GetByIdAsync(cmd.Id, ct)
                      ?? throw new NotFoundException("Product not found");

        repo.AttachAndSetRowVersion(product, Convert.FromBase64String(cmd.RowVersion));

        await repo.UpdateProductAsync(product, cmd, files, ct);

        await keyUpdater.UpdateCategoryPropertyKeysAsync(
            cmd.CategoryId,
            cmd.ParsedAttributes.Select(a => a.Key),
            ct);

        var updated = await repo.GetByIdAsync(cmd.Id, ct);
        return mapper.Map<ProductDto>(updated!);
    }
}