using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetUserReviewsAdmin;

public class GetUserReviewsAdminHandler(IReviewRepository repo)
    : IRequestHandler<GetUserReviewsAdminQuery, List<ReviewDto>>
{
    public Task<List<ReviewDto>> Handle(GetUserReviewsAdminQuery request, CancellationToken ct)
    {
        return repo.GetUserReviewsAsync(request.UserId, ct);
    }
}