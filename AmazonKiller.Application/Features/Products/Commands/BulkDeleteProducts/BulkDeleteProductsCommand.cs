using AmazonKiller.Application.DTOs.Common;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.BulkDeleteProducts;

public record BulkDeleteProductsCommand(List<Guid> Ids) : IRequest<BulkDeleteResultDto>;