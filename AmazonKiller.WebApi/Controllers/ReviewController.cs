using AmazonKiller.Application.Features.Reviews.Commands.CreateReview;
using AmazonKiller.Application.Features.Reviews.Commands.DeleteReview;
using AmazonKiller.Application.Features.Reviews.Commands.LikeReview;
using AmazonKiller.Application.Features.Reviews.Commands.UpdateReview;
using AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;
using AmazonKiller.Application.Features.Reviews.Queries.GetAverageRating;
using AmazonKiller.Application.Features.Reviews.Queries.GetReviewsByProductId;
using AmazonKiller.Application.Features.Reviews.Queries.GetReviewById;
using AmazonKiller.Application.Features.Reviews.Queries.GetReviewCount;
using AmazonKiller.Application.Features.Reviews.Queries.IsReviewExists;
using AmazonKiller.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllReviewsQuery query)
    {
        var reviews = await mediator.Send(query);
        return Ok(reviews);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var review = await mediator.Send(new GetReviewByIdQuery(id));
        return Ok(review);
    }

    [HttpGet("product/{productId:guid}/reviews")]
    public async Task<IActionResult> GetReviewsByProductId(Guid productId, [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20)
    {
        var reviews = await mediator.Send(new GetReviewsByProductIdQuery(productId, page, pageSize));
        return Ok(reviews);
    }

    [HttpGet("product/{productId:guid}/average-rating")]
    public async Task<IActionResult> GetAverageRating(Guid productId)
    {
        var avg = await mediator.Send(new GetAverageRatingQuery(productId));
        return Ok(avg);
    }

    [HttpGet("product/{productId:guid}/count")]
    public async Task<IActionResult> GetReviewCount(Guid productId)
    {
        var count = await mediator.Send(new GetReviewCountQuery(productId));
        return Ok(count);
    }

    [HttpGet("{id:guid}/exists")]
    public async Task<IActionResult> IsExists(Guid id)
    {
        var exists = await mediator.Send(new IsReviewExistsQuery(id));
        return Ok(exists);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateReviewCommand command)
    {
        var dto = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReviewCommand cmd)
    {
        if (id != cmd.Id)
            return this.ProblemBadRequest("ID mismatch");

        var exists = await mediator.Send(new IsReviewExistsQuery(id));
        if (!exists)
            return this.ProblemNotFound($"Entity with ID {id} not found");

        var updated = await mediator.Send(cmd);
        return Ok(updated);
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await mediator.Send(new DeleteReviewCommand(id));
        return deleted ? NoContent() : NotFound();
    }

    [Authorize]
    [HttpPost("{id:guid}/like")]
    public async Task<IActionResult> Like(Guid id)
    {
        await mediator.Send(new LikeReviewCommand(id));
        return NoContent();
    }
}