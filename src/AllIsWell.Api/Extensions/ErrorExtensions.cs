using AllIsWell.Shared.Kernel;
using Microsoft.AspNetCore.Mvc;

namespace AllIsWell.Api.Extensions;

public static class ErrorExtensions
{
    public static IActionResult ToProblem(this ControllerBase controller, Error error)
    {
        int statusCode = GetStatusCode(error.Type);

        return controller.Problem(
            statusCode: statusCode,
            title: error.Code,
            detail: error.Description);
    }

    private static int GetStatusCode(ErrorType errorType)
    {
        switch (errorType)
        {
            case ErrorType.Validation:
                return StatusCodes.Status400BadRequest;
            case ErrorType.Unauthorized:
                return StatusCodes.Status401Unauthorized;
            case ErrorType.NotFound:
                return StatusCodes.Status404NotFound;
            case ErrorType.Conflict:
                return StatusCodes.Status409Conflict;
            default:
                return StatusCodes.Status500InternalServerError;
        }
    }
}
