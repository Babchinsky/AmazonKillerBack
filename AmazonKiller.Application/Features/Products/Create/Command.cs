using AmazonKiller.Application.DTOs;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Create;

public record CreateProductCommand(
    string Name,
    List<string> ProductPics,
    decimal Price,
    int Quantity,
    Guid CategoryId,
    Guid DetailsId
) : IRequest<ProductDto>;