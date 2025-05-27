using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.DeleteReview;

public class DeleteReviewHandler(
    IReviewRepository reviewRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService)
    : IRequestHandler<DeleteReviewCommand, bool>
{
    public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var review = await reviewRepo.GetEntityByIdAsync(request.Id, ct);
        if (review is null) return false;

        var isOwner = review.UserId == currentUserId;
        var role = await accountRepo.GetRoleAsync(currentUserId, ct);
        var isAdmin = role == Role.Admin;

        if (!isOwner && !isAdmin)
            throw new AppException("Forbidden", 403);

        await reviewRepo.DeleteAsync(review, ct);
        return true;
    }
}