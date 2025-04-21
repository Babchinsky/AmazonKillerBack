using AmazonKiller.Application.DTOs;
using AmazonKiller.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.GetAll;

public class GetAllProductsHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await repo.GetAllAsync();
        return mapper.Map<List<ProductDto>>(products);
    }
}