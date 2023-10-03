using System.Net;
using FacultyEvaluationSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FacultyEvaluationSystem.Services;

public class AccountService : IAccountService
{
    private readonly ILogger<AccountService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public AccountService(ILogger<AccountService> logger, UserManager<User> userManager, ITokenService tokenService)
    {
        _logger = logger;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<ServiceResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
    {
        User? user = await _userManager.FindByEmailAsync(request.Email!);
        if (user is null) return new() { Code = HttpStatusCode.BadRequest, Message = "Invalid sign in credentials" };
        
        string? saltedPassword = Security.GenerateSaltedPassword(request.Password!, user.PasswordSalt!);
        if (await _userManager.CheckPasswordAsync(user, saltedPassword))
        {
            try
            {
                AuthenticationResponse response = new()
                {
                    AccessToken = await _tokenService.GenerateAccessTokenAsync(user),
                    RefreshToken = _tokenService.GenerateRefreshToken()
                };

                user.RefreshToken = response.RefreshToken;
                user.RefreshTokenExpiry = DateTime.Now.AddDays(7);
                user.UpdatedOn = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);
                return new() { Code = HttpStatusCode.OK, Message = "Sign in successful", Value = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured whiles trying to generate tokens for user with id:{id}", user.Id);
                return new() 
                { 
                    Code = HttpStatusCode.InternalServerError, 
                    Message = "An error occured whiles trying to update records"
                };
            }
        }
        return new() { Code = HttpStatusCode.BadRequest, Message = "Invalid sign in credentials" };
    }
}
