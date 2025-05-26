using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.CreateReview;
using AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.UpdateReview;
using AmazonKiller.Application.Features.Reviews.Commands.DeleteReview;
using AmazonKiller.Application.Features.Reviews.Commands.LikeReview;
using AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;
using AmazonKiller.Application.Features.Reviews.Queries.GetReviewById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ReviewDto>>> GetAll([FromQuery] GetAllReviewsQuery query, CancellationToken ct)
    {
        return Ok(await mediator.Send(query, ct));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> GetById(Guid id, CancellationToken ct)
    {
        return Ok(await mediator.Send(new GetReviewByIdQuery(id), ct));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> Create([FromForm] CreateReviewCommand cmd, CancellationToken ct)
    {
        return Ok(await mediator.Send(cmd, ct));
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> Update(Guid id, [FromForm] UpdateReviewCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id) return Problem("ID mismatch");
        return Ok(await mediator.Send(cmd, ct));
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await mediator.Send(new DeleteReviewCommand(id), ct);
        return result ? NoContent() : NotFound();
    }

    [Authorize]
    [HttpPost("{reviewId:guid}/like")]
    public async Task<IActionResult> ToggleLike(Guid reviewId, CancellationToken ct)
    {
        await mediator.Send(new LikeReviewCommand(reviewId), ct);
        return Ok();
    }
}