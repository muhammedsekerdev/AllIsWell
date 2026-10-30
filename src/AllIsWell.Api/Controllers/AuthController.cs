using AllIsWell.Api.Contracts.Auth;
using AllIsWell.Api.Extensions;
using AllIsWell.Shared.Kernel;
using AllIsWell.Users.Application.Register;
using Microsoft.AspNetCore.Mvc;

namespace AllIsWell.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly RegisterUserHandler _registerUserHandler;

    public AuthController(RegisterUserHandler registerUserHandler)
    {
        _registerUserHandler = registerUserHandler;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        RegisterUserCommand command = new RegisterUserCommand(request.Email, request.Password);

        Result<Guid> result = await _registerUserHandler.HandleAsync(command, cancellationToken);

        if (result.IsFailure)
        {
            return this.ToProblem(result.Error);
        }

        return Ok(new { id = result.Value });
    }
}
