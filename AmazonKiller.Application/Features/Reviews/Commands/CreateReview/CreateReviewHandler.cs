using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewHandler(
    IReviewRepository repo,
    IMapper mapper,
    IFileStorage files)
    : IRequestHandler<CreateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken ct)
    {
        // сохраняем файлы
        var paths = new List<string>();
        foreach (var f in request.UploadedFiles)
        {
            await using var s = f.OpenReadStream();
            paths.Add(await files.SaveAsync(s, Path.GetExtension(f.FileName), ct));
        }

        var review = new Review
        {
            ProductId = request.ProductId,
            UserId = request.UserId,
            Rating = (Rating)request.Rating,
            Content = new ReviewContent
            {
                Article = request.Article,
                Message = request.Message,
                FilePaths = paths
            }
        };

        await repo.AddAsync(review);
        return mapper.Map<ReviewDto>(review);
    }
}