using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.Interfaces;
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