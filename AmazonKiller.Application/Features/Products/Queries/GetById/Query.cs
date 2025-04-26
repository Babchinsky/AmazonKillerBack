using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;