using AmazonKiller.Application.Interfaces.Services.Recalculation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Controllers.Admin;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/admin/maintenance")]
public class AdminMaintenanceController(
    IProductRatingService ratingSvc,
    ICategoryFilterService categoryFilterSvc) : ControllerBase
{
    [HttpPost("recalculate-ratings")]
    public async Task<IActionResult> RecalcRatings(CancellationToken ct)
    {
        await ratingSvc.RecalculateAsync(ct);
        return NoContent();
    }

    [HttpPost("recalculate-category-filters")]
    public async Task<IActionResult> RecalcCategoryFilters(CancellationToken ct)
    {
        await categoryFilterSvc.RecalculateAsync(ct);
        return NoContent();
    }
}