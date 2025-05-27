using AmazonKiller.Application.Features.Products.Public.Queries.GetAllProductCards;
using AmazonKiller.Application.Features.Products.Public.Queries.GetProductById;
using AmazonKiller.Application.Features.Products.Public.Queries.IsProductExists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public;

[ApiController]
[Route("api/products")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllActiveProductCardsQuery q, CancellationToken ct)
    {
        var list = await mediator.Send(q, ct);
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var dto = await mediator.Send(new GetProductByIdQuery(id), ct);
        return Ok(dto);
    }

    [HttpGet("{id:guid}/exists")]
    public async Task<IActionResult> Exists(Guid id, CancellationToken ct)
    {
        var exists = await mediator.Send(new IsProductExistsQuery(id), ct);
        return Ok(exists);
    }
}