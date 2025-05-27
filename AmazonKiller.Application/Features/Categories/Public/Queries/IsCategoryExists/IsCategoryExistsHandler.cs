using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.IsCategoryExists;

public class IsCategoryExistsHandler(
    ICategoryQueryService categoryQueryService,
    ICurrentUserService currentUser,
    IAccountRepository accountRepo
) : IRequestHandler<IsCategoryExistsQuery, bool>
{
    public async Task<bool> Handle(IsCategoryExistsQuery request, CancellationToken ct)
    {
        bool isAdmin;
        try
        {
            isAdmin = await accountRepo.GetRoleAsync(currentUser.UserId, ct) == Role.Admin;
        }
        catch (UnauthorizedAccessException)
        {
            isAdmin = false;
        }

        return await categoryQueryService.IsVisibleAsync(request.Id, isAdmin, ct);
    }
}