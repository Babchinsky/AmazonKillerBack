using AmazonKiller.Application.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Address;

[ApiController]
[Route("api/countries")]
public class CountryController(ICountryService countryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var countries = await countryService.GetCountriesAsync(ct);
        return Ok(countries);
    }
}