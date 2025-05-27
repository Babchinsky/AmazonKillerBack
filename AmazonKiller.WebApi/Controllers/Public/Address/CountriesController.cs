using AmazonKiller.Application.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Public.Address;

[ApiController]
[Route("api/countries")]
public class CountriesController(ICountryService countryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var countries = await countryService.GetCountriesAsync(ct);
        return Ok(countries);
    }
}