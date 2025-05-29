using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Create;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Update;
using AmazonKiller.Application.Features.Collections.Admin.Commands.DeleteCollection;
using AmazonKiller.WebApi.Controllers.Public;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[Route("api/admin/collections")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminCollectionsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CollectionDetailsDto>> Create(
        [FromForm] CreateCollectionCommand cmd)
    {
        var dto = await mediator.Send(cmd);
        return CreatedAtAction(
            nameof(CollectionsController.GetById),
            "Collections",
            new { id = dto.Id },
            dto
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CollectionDetailsDto>> Update(
        Guid id, [FromForm] UpdateCollectionCommand cmd)
    {
        if (id != cmd.Id) return BadRequest("ID mismatch");
        var dto = await mediator.Send(cmd);
        return Ok(dto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteCollectionCommand(id));
        return NoContent();
    }
}