using System.Net;
using FacultyEvaluationSystem.Domain;
using FacultyEvaluationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacultyEvaluationSystem.API;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AuthenticationController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        ServiceResponse<AuthenticationResponse> response = await _accountService.AuthenticateAsync(request);

        return response.Code switch
        {
            HttpStatusCode.BadRequest => BadRequest(response.Message),
            HttpStatusCode.InternalServerError => StatusCode(500, "System Error"),
            _ => Ok(response.Value),
        };
    }
}
