using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Queries.GetProductByIdAdmin;

public record GetProductByIdAdminQuery(Guid Id) : IRequest<ProductDto>;