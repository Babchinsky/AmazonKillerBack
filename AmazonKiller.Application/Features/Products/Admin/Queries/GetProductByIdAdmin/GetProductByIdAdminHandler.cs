using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Queries.GetProductByIdAdmin;

public class GetProductByIdAdminHandler(
    IProductRepository productRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    IMapper mapper)
    : IRequestHandler<GetProductByIdAdminQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdAdminQuery request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var product = await productRepo.GetByIdAsync(request.Id, ct);
        return product is null ? null : mapper.Map<ProductDto>(product);
    }
}