using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.CreateReview;
using AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.UpdateReview;
using AmazonKiller.Application.Features.Reviews.Account.Commands.DeleteReview;
using AmazonKiller.Application.Features.Reviews.Account.Commands.LikeReview;
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
        return Ok(await mediator.Send(cmd, ct));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ReviewDto>> Update(Guid id, [FromForm] UpdateReviewCommand cmd, CancellationToken ct)
    {
        return id != cmd.Id ? Problem("ID mismatch") : Ok(await mediator.Send(cmd, ct));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await mediator.Send(new DeleteReviewCommand(id), ct);
        return result ? NoContent() : NotFound();
    }

    [HttpPost("{reviewId:guid}/like")]
    public async Task<IActionResult> ToggleLike(Guid reviewId, CancellationToken ct)
    {
        await mediator.Send(new LikeReviewCommand(reviewId), ct);
        return Ok();
    }
}