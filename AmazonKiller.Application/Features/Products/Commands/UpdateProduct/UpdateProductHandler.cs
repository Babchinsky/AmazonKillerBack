using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id);
        if (product is null)
            return null;

        mapper.Map(request, product);
        await repo.UpdateAsync(product);

        return mapper.Map<ProductDto>(product);
    }
}