using AmazonKiller.Application.DTOs;
using MediatR;

namespace AmazonKiller.Application.Features.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;