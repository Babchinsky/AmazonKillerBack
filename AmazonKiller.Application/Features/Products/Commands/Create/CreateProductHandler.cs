using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.Create;

public class CreateProductHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);
        product.Id = Guid.NewGuid();
        // product.CategoryId = Guid.Empty; // временно
        await repo.AddAsync(product);
        return mapper.Map<ProductDto>(product);
    }
}