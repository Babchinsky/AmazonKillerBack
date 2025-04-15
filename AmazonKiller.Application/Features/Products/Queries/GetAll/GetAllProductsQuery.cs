using AmazonKiller.Application.DTOs;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.GetAll;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;