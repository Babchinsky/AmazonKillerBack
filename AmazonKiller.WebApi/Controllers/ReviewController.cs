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
    public async Task<ActionResult<List<ReviewDto>>> GetAll([FromQuery] GetAllReviewsQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> GetById(Guid id)
    {
        return Ok(await mediator.Send(new GetReviewByIdQuery(id)));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> Create([FromForm] CreateReviewCommand cmd)
    {
        return Ok(await mediator.Send(cmd));
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> Update(Guid id, [FromForm] UpdateReviewCommand cmd)
    {
        if (id != cmd.Id) return Problem("ID mismatch");
        return Ok(await mediator.Send(cmd));
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteReviewCommand(id));
        return result ? NoContent() : NotFound();
    }

    [Authorize]
    [HttpPost("{reviewId:guid}/like")]
    public async Task<IActionResult> ToggleLike(Guid reviewId)
    {
        await mediator.Send(new LikeReviewCommand(reviewId));
        return Ok();
    }
}