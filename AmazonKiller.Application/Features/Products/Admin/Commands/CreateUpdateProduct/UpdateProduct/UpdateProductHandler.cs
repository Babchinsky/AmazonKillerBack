using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.UpdateProduct;

public class UpdateProductHandler(
    IProductRepository repo,
    IPropertyKeyUpdater keyUpdater,
    IMapper mapper,
    IFileStorage fileStorage)
    : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand cmd, CancellationToken ct)
    {
        await repo.UpdateAsync(cmd, fileStorage, ct);

        await keyUpdater.UpdateCategoryPropertyKeysAsync(
            cmd.CategoryId,
            cmd.ParsedAttributes.Select(a => a.Key),
            ct);

        var updated = await repo.GetByIdAsync(cmd.Id, ct);
        return mapper.Map<ProductDto>(updated!);
    }
}