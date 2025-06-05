using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Products;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.CreateProduct;

public class CreateProductHandler(
    IFileStorage fileStorage,
    IProductRepository productRepo,
    ICategoryRepository categoryRepo,
    IMapper mapper,
    IPropertyKeyUpdater propertyKeyUpdater)
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand cmd, CancellationToken ct)
    {
        var category = await categoryRepo.GetByIdAsync(cmd.CategoryId, ct);
        if (category is null)
            throw new NotFoundException("Category not found.");

        // if (category.ParentId == null)
        //     throw new AppException("Products can only be added to subcategories.");

        // 🧠 Обновляем PropertyKeys через сервис
        var usedKeys = cmd.ParsedAttributes.Select(a => a.Key).Distinct().ToList();
        await propertyKeyUpdater.UpdateCategoryPropertyKeysAsync(cmd.CategoryId, usedKeys, ct);

        if (cmd.Images is null || cmd.Images.Count == 0)
            throw new AppException("At least one image is required.");

        var uploadedUrls = new List<string>();

        try
        {
            foreach (var image in cmd.Images)
            {
                await using var stream = image.OpenReadStream();
                var extension = Path.GetExtension(image.FileName);
                var url = await fileStorage.SaveAsync(stream, extension, ct);
                uploadedUrls.Add(url);
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Code = cmd.Code,
                Name = cmd.Name,
                CategoryId = cmd.CategoryId,
                Price = cmd.Price,
                DiscountPercent = cmd.DiscountPercent,
                Quantity = cmd.Quantity,
                ImageUrls = uploadedUrls
            };

            await productRepo.AddAsync(product, ct);

            var attributes = cmd.ParsedAttributes.Select(x => new ProductAttribute
            {
                Id = Guid.NewGuid(),
                Key = x.Key,
                Value = x.Value,
                ProductId = product.Id
            }).ToList();

            var features = cmd.ParsedFeatures.Select(x => new ProductFeature
            {
                Id = Guid.NewGuid(),
                Name = x.Name,
                Description = x.Description,
                ProductId = product.Id
            }).ToList();

            await productRepo.AddAttributesAndFeaturesAsync(attributes, features, ct);

            var created = await productRepo.GetByIdAsync(product.Id, ct); // вернуть со связанными данными
            return mapper.Map<ProductDto>(created);
        }
        catch
        {
            foreach (var url in uploadedUrls)
                await fileStorage.DeleteAsync(url, ct);

            throw;
        }
    }
}