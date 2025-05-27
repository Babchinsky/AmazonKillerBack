using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;