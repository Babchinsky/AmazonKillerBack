using Microsoft.AspNetCore.Mvc;

namespace AmazonKiller.WebApi.Extensions;

public static class ControllerExtensions
{
    public static IActionResult ProblemNotFound(this ControllerBase controller, string detail) =>
        controller.Problem(title: "Not found", detail: detail, statusCode: StatusCodes.Status404NotFound);

    public static IActionResult ProblemBadRequest(this ControllerBase controller, string detail) =>
        controller.Problem(title: "Bad request", detail: detail, statusCode: StatusCodes.Status400BadRequest);
}