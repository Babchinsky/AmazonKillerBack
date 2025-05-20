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

        // Установим оригинальную версию до любых изменений
        var rowVersion = Convert.FromBase64String(cmd.RowVersion);
        // repo.AttachAndSetRowVersion(product, rowVersion);

        // Обновляем всё
        await repo.UpdateAsync(product, cmd, files, rowVersion, ct);

        // Обновляем PropertyKeys категории
        await keyUpdater.UpdateCategoryPropertyKeysAsync(
            cmd.CategoryId,
            cmd.ParsedAttributes.Select(a => a.Key),
            ct);

        // Возвращаем уже обновлённую сущность (с новым RowVersion)
        var updated = await repo.GetByIdAsync(cmd.Id, ct);
        return mapper.Map<ProductDto>(updated!);
    }
}