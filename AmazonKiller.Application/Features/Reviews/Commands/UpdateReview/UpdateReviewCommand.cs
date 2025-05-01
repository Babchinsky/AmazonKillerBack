using AmazonKiller.Application.DTOs.Reviews;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Reviews.Commands.UpdateReview;

public record UpdateReviewCommand(
    Guid Id,
    string Article,
    string Message,
    List<IFormFile> UploadedFiles,
    int Rating
) : IRequest<ReviewDto>;