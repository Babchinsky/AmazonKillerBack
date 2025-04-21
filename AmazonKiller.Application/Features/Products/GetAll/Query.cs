using AmazonKiller.Application.DTOs;
using MediatR;

namespace AmazonKiller.Application.Features.Products.GetAll;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;