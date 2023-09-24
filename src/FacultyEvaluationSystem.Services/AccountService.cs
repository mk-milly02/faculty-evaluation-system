using FacultyEvaluationSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FacultyEvaluationSystem.Services;

public class AccountService : IAccountService
{
    private readonly ILogger<AccountService> _logger;
    private readonly UserManager<User> _userManager;

    public AccountService(ILogger<AccountService> logger, UserManager<User> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<AuthenticationResponse?> AuthenticateAsync(AuthenticationRequest request)
    {
        User? user = await _userManager.FindByEmailAsync(request.Email!);
        if (user is null) return null;
        return new();
    }
}
