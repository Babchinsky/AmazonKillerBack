using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Public.Queries.GetAllCategories;
using AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryById;
using AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryFilters;
using AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryTree;
using AmazonKiller.Application.Features.Categories.Public.Queries.IsCategoryExists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public;

[ApiController]
[Route("api/categories")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public Task<PagedList<CategoryDto>> GetAll([FromQuery] GetAllCategoriesQuery q, CancellationToken ct)
    {
        return mediator.Send(q, ct);
    }

    [HttpGet("tree")]
    public Task<List<CategoryTreeDto>> GetTree(CancellationToken ct)
    {
        return mediator.Send(new GetCategoryTreeQuery(), ct);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var dto = await mediator.Send(new GetCategoryByIdQuery(id), ct);
        return Ok(dto);
    }

    [HttpGet("{id:guid}/exists")]
    public Task<bool> Exists(Guid id, CancellationToken ct)
    {
        return mediator.Send(new IsCategoryExistsQuery(id), ct);
    }

    [HttpGet("{id:guid}/filters")]
    public async Task<IActionResult> GetFilters(Guid id, CancellationToken ct)
    {
        var result = await mediator.Send(new GetCategoryFiltersQuery(id), ct);
        return Ok(result);
    }
}