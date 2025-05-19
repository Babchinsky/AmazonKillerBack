using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await repo.GetByIdAsync(request.Id, cancellationToken);
        return product is null ? null : mapper.Map<ProductDto>(product);
    }
}