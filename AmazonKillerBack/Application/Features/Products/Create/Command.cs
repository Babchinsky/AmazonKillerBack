namespace AmazonKillerBack.Application.Features.Products.Create;

using DTOs;
using MediatR;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    string? ImageUrl,
    int Stock,
    Guid CategoryId
) : IRequest<ProductDto>;