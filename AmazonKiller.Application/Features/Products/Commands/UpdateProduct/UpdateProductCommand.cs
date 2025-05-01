using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    byte[] RowVersion,
    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId,
    IReadOnlyCollection<string> ImageUrls,
    IReadOnlyCollection<AttributeDto> Attributes,
    IReadOnlyCollection<FeatureDto> Features
) : IRequest<ProductDto>;