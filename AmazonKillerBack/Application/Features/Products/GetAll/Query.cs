using AmazonKillerBack.Application.DTOs;
using MediatR;

namespace AmazonKillerBack.Application.Features.Products.GetAll;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;