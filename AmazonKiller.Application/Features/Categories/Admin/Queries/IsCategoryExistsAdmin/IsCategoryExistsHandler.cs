using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.IsCategoryExistsAdmin;

public class IsCategoryExistsAdminHandler(
    ICategoryRepository categoryRepo,
    ICurrentUserService currentUser,
    IAccountRepository accountRepo
) : IRequestHandler<IsCategoryExistsAdminQuery, bool>
{
    public async Task<bool> Handle(IsCategoryExistsAdminQuery request, CancellationToken ct)
    {
        var userId = currentUser.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var category = await categoryRepo.GetByIdAsync(request.Id, ct);
        return category is not null;
    }
}