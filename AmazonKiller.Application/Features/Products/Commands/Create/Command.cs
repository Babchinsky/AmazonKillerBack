using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.Create;

public record CreateProductCommand(
    string Name,
    List<string> ProductPics,
    decimal Price,
    int Quantity,
    Guid CategoryId,
    Guid DetailsId
) : IRequest<ProductDto>;