using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Commands.BulkDeleteCategories;
using AmazonKiller.Application.Features.Categories.Commands.CreateCategory;
using AmazonKiller.Application.Features.Categories.Commands.UpdateCategory;
using AmazonKiller.Application.Features.Categories.Queries.GetAllCategories;
using AmazonKiller.Application.Features.Categories.Queries.GetCategoryById;
using AmazonKiller.Application.Features.Categories.Queries.GetCategoryTree;
using AmazonKiller.Application.Features.Categories.Queries.IsCategoryExists;
using AmazonKiller.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public Task<List<CategoryDto>> GetAll(CancellationToken ct)
    {
        return mediator.Send(new GetAllCategoriesQuery(), ct);
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand cmd, CancellationToken ct)
    {
        var result = await mediator.Send(cmd, ct);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand cmd, CancellationToken ct)
    {
        if (id != cmd.Id) return this.ProblemBadRequest("ID mismatch");
        var updated = await mediator.Send(cmd, ct);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await mediator.Send(new BulkDeleteCategoriesCommand([id]), ct);
        return NoContent();
    }

    [HttpPost("delete-many")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteCategoriesCommand cmd, CancellationToken ct)
    {
        await mediator.Send(cmd, ct);
        return NoContent();
    }
}