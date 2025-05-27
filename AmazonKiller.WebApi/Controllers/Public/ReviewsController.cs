using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Public.Queries.GetAllReviews;
using AmazonKiller.Application.Features.Reviews.Public.Queries.GetReviewById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public;

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
}