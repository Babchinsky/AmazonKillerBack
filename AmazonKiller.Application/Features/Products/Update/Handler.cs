using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Update;

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