using AmazonKiller.Application.DTOs.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetUserReviewsAdmin;

public record GetUserReviewsAdminQuery(Guid UserId) : IRequest<List<ReviewDto>>;