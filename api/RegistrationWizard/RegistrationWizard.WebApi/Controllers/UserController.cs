using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Application.Commands.RegisterUser;

namespace RegistrationWizard.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly RegisterUserHandler _registerUserHandler;

    public UserController(RegisterUserHandler registerUserHandler)
    {
        _registerUserHandler = registerUserHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        await _registerUserHandler.HandleAsync(command);
        return Ok();
    }
}
