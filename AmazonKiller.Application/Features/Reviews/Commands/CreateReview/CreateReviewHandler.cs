using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<CreateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            ProductId = request.ProductId,
            UserId = request.UserId,
            Rating = (Rating)request.Rating,
            Content = new ReviewContent
            {
                Article = request.Article,
                Message = request.Message,
                UploadedFiles = request.UploadedFiles
            }
        };

        await repo.AddAsync(review);
        return mapper.Map<ReviewDto>(review);
    }
}