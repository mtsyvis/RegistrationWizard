using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Application.Commands.RegisterUser;
using RegistrationWizard.WebApi.Abstractions;

namespace RegistrationWizard.WebApi.Controllers;

[Route("api/users")]
public class UserController : ApiController
{
    public UserController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
