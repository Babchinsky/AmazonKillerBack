using AmazonKiller.Application.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public.Address;

[ApiController]
[Route("api/nova-poshta")]
public class NovaPoshtaController(INovaPoshtaService service) : ControllerBase
{
    [HttpGet("regions")]
    public async Task<IActionResult> GetRegions(CancellationToken ct)
    {
        var regions = await service.GetRegionsAsync(ct);
        return Ok(regions);
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetCities([FromQuery] string region, CancellationToken ct)
    {
        var cities = await service.GetCitiesAsync(region, ct);
        return Ok(cities);
    }
}