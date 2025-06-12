using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.CreateReview;
using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.UpdateReview;
using AmazonKiller.Application.Features.Reviews.Account.Commands.DeleteOwnReview;
using AmazonKiller.Application.Features.Reviews.Account.Commands.LikeReview;
using AmazonKiller.Application.Features.Reviews.Public.Queries.GetReviewById;
using AmazonKiller.WebApi.Controllers.Public;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/account/reviews")]
[Authorize]
public class AccountReviewsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> Create([FromForm] CreateReviewCommand cmd, CancellationToken ct)
    {
        var id = await mediator.Send(cmd, ct);
        var dto = await mediator.Send(new GetReviewByIdQuery(id), ct);
        return CreatedAtAction(
            actionName: nameof(ReviewsController.GetById),
            controllerName: "Reviews",
            routeValues: new { id },
            value: dto);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> Update(Guid id, [FromForm] UpdateReviewCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id) return Problem("ID mismatch");

        var updatedId = await mediator.Send(cmd, ct);
        var dto = await mediator.Send(new GetReviewByIdQuery(updatedId), ct);
        return Ok(dto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await mediator.Send(new DeleteOwnReviewCommand(id), ct);
        return result ? NoContent() : NotFound();
    }

    [HttpPost("{reviewId:guid}/like")]
    public async Task<IActionResult> ToggleLike(Guid reviewId, CancellationToken ct)
    {
        await mediator.Send(new LikeReviewCommand(reviewId), ct);
        return Ok();
    }
}