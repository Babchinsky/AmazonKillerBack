namespace AmazonKillerBack.Application.Features.Products.Create;

using DTOs;
using Interfaces;
using Domain.Entities;
using AutoMapper;
using MediatR;

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