using FacultyEvaluationSystem.Domain;
using FacultyEvaluationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacultyEvaluationSystem.API;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        string? userId = await _userService.CreateUserAsync(request);

        return userId is null 
            ? StatusCode(500, "Failed to create user") 
            : CreatedAtAction("GetStudentAsync", userId, new());
    }
}
