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
    ICategoryRepository categoryRepo,
    IPropertyKeyUpdater keyUpdater,
    IFileStorage files,
    IMapper mapper)
    : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand cmd, CancellationToken ct)
    {
        var product = await repo.GetByIdAsync(cmd.Id, ct)
                      ?? throw new NotFoundException("Product not found");

        var category = await categoryRepo.GetByIdAsync(cmd.CategoryId, ct)
                       ?? throw new NotFoundException("Category not found");

        if (category.ParentId == null)
            throw new AppException("Products can only be assigned to subcategories.");

        var usedKeys = cmd.ParsedAttributes.Select(a => a.Key).Distinct().ToList();
        await keyUpdater.UpdateCategoryPropertyKeysAsync(cmd.CategoryId, usedKeys, ct);

        var rowVersionBytes = Convert.FromBase64String(cmd.RowVersion);

        // --- обработка изображений ---
        var removed = product.ProductPics.Except(cmd.ExistingImageUrls).ToList();
        await Task.WhenAll(removed.Select(url => files.DeleteAsync(url, ct)));

        var uploadedUrls = new List<string>();
        foreach (var image in cmd.NewImages)
        {
            await using var stream = image.OpenReadStream();
            var ext = Path.GetExtension(image.FileName);
            var url = await files.SaveAsync(stream, ext, ct);
            uploadedUrls.Add(url);
        }

        product.ProductPics.Clear();
        product.ProductPics.AddRange(cmd.ExistingImageUrls);
        product.ProductPics.AddRange(uploadedUrls);

        // --- обработка атрибутов и фич ---
        product.Attributes.Clear();
        foreach (var a in cmd.ParsedAttributes)
        {
            product.Attributes.Add(new ProductAttribute
            {
                Id = Guid.NewGuid(),
                Key = a.Key,
                Value = a.Value,
                ProductId = product.Id
            });
        }

        product.Features.Clear();
        foreach (var f in cmd.ParsedFeatures)
        {
            product.Features.Add(new ProductFeature
            {
                Id = Guid.NewGuid(),
                Name = f.Name,
                Description = f.Description,
                ProductId = product.Id
            });
        }

        product.Name = cmd.Name;
        product.CategoryId = cmd.CategoryId;
        product.Price = cmd.Price;
        product.Quantity = cmd.Quantity;

        await repo.UpdateAsync(product, rowVersionBytes, ct);
        return mapper.Map<ProductDto>(product);
    }
}