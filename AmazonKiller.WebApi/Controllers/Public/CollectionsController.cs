using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Public.Queries.GetAllCollections;
using AmazonKiller.Application.Features.Collections.Public.Queries.GetCollectionById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public;

[Route("api/collections")]
[ApiController]
public class CollectionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedList<CollectionCardDto>>> GetAll([FromQuery] GetAllCollectionsQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CollectionDetailsDto>> GetById(Guid id)
    {
        return Ok(await mediator.Send(new GetCollectionByIdQuery(id)));
    }
}