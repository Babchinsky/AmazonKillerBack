using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Sales;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductHandler(
    IProductRepository repo,
    IMapper mapper) // файлы уже загружены контроллером
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand cmd, CancellationToken ct)
    {
        // mapper создаёт Product; Id/Code остаются как прописано в самой сущности
        var product = mapper.Map<Product>(cmd);

        foreach (var url in cmd.ImageUrls)
            product.ProductPics.Add(url);

        if (cmd.Discount is { } d)
            product.Sale = new Sale
            {
                Id = Guid.NewGuid(),
                OldPrice = cmd.Price,
                NewPrice = d,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue
            };

        await repo.AddAsync(product);
        return mapper.Map<ProductDto>(product);
    }
}