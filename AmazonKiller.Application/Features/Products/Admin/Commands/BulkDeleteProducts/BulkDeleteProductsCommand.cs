using AmazonKiller.Application.DTOs.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.BulkDeleteProducts;

public record BulkDeleteProductsCommand(List<Guid> Ids) : IRequest<BulkDeleteResultDto>;