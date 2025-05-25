using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.Features.Account.Wishlist.Commands.AddToWishlist;
using AmazonKiller.Application.Features.Account.Wishlist.Commands.DeleteFromWishlist;
using AmazonKiller.Application.Features.Account.Wishlist.Commands.ToggleWishlist;
using AmazonKiller.Application.Features.Account.Wishlist.Queries.GetWishlist;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Account;

[ApiController]
[Route("api/wishlist")]
[Authorize]
public class WishlistController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? searchTerm, [FromQuery] QueryParameters parameters)
    {
        var result = await mediator.Send(new GetWishlistQuery
        {
            SearchTerm = searchTerm,
            Parameters = parameters
        });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddToWishlistCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("toggle")]
    public async Task<IActionResult> Toggle([FromBody] ToggleWishlistCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> Delete(Guid productId)
    {
        await mediator.Send(new DeleteFromWishlistCommand(productId));
        return NoContent();
    }
}