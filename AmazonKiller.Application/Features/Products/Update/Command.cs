using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Update;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> ProductPics,
    decimal Price,
    int Quantity,
    Guid CategoryId,
    Guid DetailsId
) : IRequest<ProductDto>;