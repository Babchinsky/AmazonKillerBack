using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Reviews.Public.Queries.GetAllReviews;

public class GetAllReviewsHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<GetAllReviewsQuery, PagedList<ReviewDto>>
{
    public async Task<PagedList<ReviewDto>> Handle(GetAllReviewsQuery q, CancellationToken ct)
    {
        var query = repo.GetAllWithIncludes()
            .AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Review, ReviewDto>(q.Parameters, mapper, ct);
    }
}