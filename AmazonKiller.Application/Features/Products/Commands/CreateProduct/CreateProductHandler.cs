using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);
        await repo.AddAsync(product);
        return mapper.Map<ProductDto>(product);
    }
}