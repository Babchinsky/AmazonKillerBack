using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Queries.IsProductExistsAdmin;

public class IsProductExistsAdminHandler(
    IProductRepository productRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo)
    : IRequestHandler<IsProductExistsAdminQuery, bool>
{
    public async Task<bool> Handle(IsProductExistsAdminQuery request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var product = await productRepo.GetByIdAsync(request.Id, ct);
        return product is not null;
    }
}