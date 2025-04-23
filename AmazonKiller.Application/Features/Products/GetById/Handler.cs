using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces;
using AmazonKiller.Application.Interfaces.Repositories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.GetById;

public class GetProductByIdHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id);
        return product is null ? null : mapper.Map<ProductDto>(product);
    }
}