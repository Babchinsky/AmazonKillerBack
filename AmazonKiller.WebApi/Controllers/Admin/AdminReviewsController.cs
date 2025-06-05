using AmazonKiller.Application.Features.Reviews.Admin.Commands.DeleteReviewByAdmin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/admin/reviews")]
public class AdminReviewsController(IMediator mediator) : ControllerBase
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await mediator.Send(new DeleteReviewByAdminCommand(id), ct);
        return result ? NoContent() : NotFound();
    }
}