using AmazonKiller.Application.DTOs.Reviews;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateReview;

public record CreateReviewCommand(
    string Article,
    string Message,
    List<IFormFile> UploadedFiles,
    decimal Rating,
    Guid ProductId,
    Guid UserId
) : IRequest<ReviewDto>;