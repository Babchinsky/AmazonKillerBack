using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.UpdateProduct;

public class UpdateProductCommand : UpsertProductModel, IRequest<ProductDto>
{
    public Guid Id { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}