using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.Common;

public class UpsertReviewModel
{
    public string Article { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public decimal Rating { get; init; }
    public List<IFormFile> UploadedFiles { get; init; } = [];
    public List<string> Tags { get; init; } = [];
}