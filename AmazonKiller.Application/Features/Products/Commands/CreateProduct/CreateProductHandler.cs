using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IFileStorage fileStorage,
    IProductRepository repo)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand cmd, CancellationToken ct)
    {
        var uploadedUrls = new List<string>();
        try
        {
            foreach (var image in cmd.Images)
            {
                await using var stream = image.OpenReadStream();
                var url = await fileStorage.SaveAsync(stream, Path.GetExtension(image.FileName), ct);
                uploadedUrls.Add(url);
            }

            var product = new Product
            {
                Code = cmd.Code,
                Name = cmd.Name,
                CategoryId = cmd.CategoryId,
                Price = cmd.Price,
                DiscountPct = cmd.DiscountPct,
                Quantity = cmd.Quantity,
                ProductPics = uploadedUrls,
                Attributes = cmd.Attributes.Select(x => new ProductAttribute
                {
                    Id = Guid.NewGuid(),
                    Key = x.Key,
                    Value = x.Value
                }).ToList(),
                Features = cmd.Features.Select(x => new ProductFeature
                {
                    Id = Guid.NewGuid(),
                    Name = x.Name,
                    Description = x.Description
                }).ToList()
            };

            await repo.AddAsync(product, ct);
            return product.Id;
        }
        catch
        {
            foreach (var url in uploadedUrls)
                await fileStorage.DeleteAsync(url, ct);
            throw;
        }
    }
}