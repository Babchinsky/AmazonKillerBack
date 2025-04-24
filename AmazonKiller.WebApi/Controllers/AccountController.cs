using AmazonKiller.Application.Features.Account.Commands.AddToWishlist;
using AmazonKiller.Application.Features.Account.Commands.ChangeName;
using AmazonKiller.Application.Features.Account.Commands.ChangePassword;
using AmazonKiller.Application.Features.Account.Commands.ConfirmEmailChange;
using AmazonKiller.Application.Features.Account.Commands.DeleteAccount;
using AmazonKiller.Application.Features.Account.Commands.DeleteFromWishlist;
using AmazonKiller.Application.Features.Account.Commands.Logout;
using AmazonKiller.Application.Features.Account.Commands.StartEmailChange;
using AmazonKiller.Application.Features.Account.Commands.ToggleWishlist;
using AmazonKiller.Application.Features.Account.Queries.GetWishlist;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost("email-change/start")]
    public async Task<IActionResult> StartEmailChange([FromBody] StartEmailChangeCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("email-change/confirm")]
    public async Task<IActionResult> ConfirmEmailChange([FromBody] ConfirmEmailChangeCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("name")]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await mediator.Send(new LogoutCommand());
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAccount()
    {
        await mediator.Send(new DeleteAccountCommand());
        return NoContent();
    }

    [HttpGet("wishlist")]
    public async Task<IActionResult> GetWishlist()
    {
        var result = await mediator.Send(new GetWishlistQuery());
        return Ok(result);
    }
    
    [Authorize]
    [HttpPost("wishlist/toggle")]
    public async Task<IActionResult> ToggleWishlist([FromBody] ToggleWishlistCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("wishlist")]
    public async Task<IActionResult> AddToWishlist([FromBody] AddToWishlistCommand cmd)
    {
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("wishlist/{productId:guid}")]
    public async Task<IActionResult> DeleteFromWishlist(Guid productId)
    {
        await mediator.Send(new DeleteFromWishlistCommand(productId));
        return NoContent();
    }
}