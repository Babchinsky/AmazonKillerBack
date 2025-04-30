using AmazonKiller.Application.Interfaces.Common.Address;
using AmazonKiller.Application.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AmazonKiller.WebApi.Controllers.Address;

[ApiController]
[Route("api/np")]
public class NovaPoshtaController(
    INovaPoshtaService service,
    IOptions<NovaPoshtaOptions> npSettings)
    : ControllerBase
{
    private readonly NovaPoshtaOptions _npSettings = npSettings.Value;

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