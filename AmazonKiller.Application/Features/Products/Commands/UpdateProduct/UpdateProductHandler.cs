using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler(
    IProductRepository repo,
    IMapper mapper) : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand cmd, CancellationToken ct)
    {
        var product = await repo.GetByIdAsync(cmd.Id)
                      ?? throw new NotFoundException("Product not found");

        mapper.Map(cmd, product); // переносим новые поля
        await repo.UpdateAsync(product, cmd.RowVersion, ct);

        return mapper.Map<ProductDto>(product);
    }
}