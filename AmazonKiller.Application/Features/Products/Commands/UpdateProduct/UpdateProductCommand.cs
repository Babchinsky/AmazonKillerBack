using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string RowVersion,
    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId,
    IReadOnlyCollection<string> ImageUrls,
    IReadOnlyCollection<ProductAttributeDto> Attributes,
    IReadOnlyCollection<ProductFeatureDto> Features
) : IRequest<ProductDto>;