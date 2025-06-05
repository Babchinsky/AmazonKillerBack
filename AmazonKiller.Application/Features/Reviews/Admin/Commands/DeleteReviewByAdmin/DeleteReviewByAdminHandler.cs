using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Admin.Commands.DeleteReviewByAdmin;

public class DeleteReviewByAdminHandler(
    IReviewRepository reviewRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo)
    : IRequestHandler<DeleteReviewByAdminCommand, bool>
{
    public async Task<bool> Handle(DeleteReviewByAdminCommand request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var review = await reviewRepo.GetEntityByIdAsync(request.Id, ct);
        if (review is null) return false;

        await reviewRepo.DeleteAsync(review, ct);
        return true;
    }
}