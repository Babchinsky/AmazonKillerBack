using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler(
    IProductRepository repo,
    IFileStorage files,
    IMapper mapper)
    : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand cmd, CancellationToken ct)
    {
        var product = await repo.GetByIdAsync(cmd.Id, ct)
                      ?? throw new NotFoundException("Product not found");

        var rowVersionBytes = Convert.FromBase64String(cmd.RowVersion);

        // ---------- изображения ---------------------------------------------
        var removed = product.ProductPics.Except(cmd.ImageUrls).ToList();
        await Task.WhenAll(removed.Select(url => files.DeleteAsync(url, ct)));

        product.ProductPics.Clear();
        foreach (var url in cmd.ImageUrls)
            product.ProductPics.Add(url);

        // ---------- атрибуты --------------------------------------------------
        product.Attributes.Clear();
        foreach (var a in cmd.Attributes)
            product.Attributes.Add(new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Key = a.Key,
                Value = a.Value
            });

        // ---------- фичи ------------------------------------------------------
        product.Features.Clear();
        foreach (var f in cmd.Features)
            product.Features.Add(new ProductFeature
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Name = f.Name,
                Description = f.Description
            });

        // ---------- простые поля ---------------------------------------------
        product.Name = cmd.Name;
        product.CategoryId = cmd.CategoryId;
        product.Price = cmd.Price;
        product.Quantity = cmd.Quantity;

        await repo.UpdateAsync(product, rowVersionBytes, ct);
        return mapper.Map<ProductDto>(product);
    }
}