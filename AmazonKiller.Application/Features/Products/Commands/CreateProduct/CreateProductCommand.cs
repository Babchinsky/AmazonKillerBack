using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    Guid CategoryId,
    Guid DetailsId,
    decimal Price,
    int Quantity,
    decimal? Discount,
    IReadOnlyCollection<string> ImageUrls,
    IReadOnlyCollection<AttributeDto> Attributes,
    IReadOnlyCollection<FeatureDto> Features
) : IRequest<ProductDto>;