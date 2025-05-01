using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<UpdateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await repo.GetByIdAsync(request.Id);
        if (review is null)
            throw new NotFoundException("Review", request.Id);

        review.Rating = (Rating)request.Rating;
        review.Content.Article = request.Article;
        review.Content.Message = request.Message;
        review.Content.UploadedFiles = request.UploadedFiles;

        await repo.UpdateAsync(review);
        return mapper.Map<ReviewDto>(review);
    }
}