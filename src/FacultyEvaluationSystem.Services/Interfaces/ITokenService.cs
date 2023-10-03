using System.Security.Claims;
using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Services;

public interface ITokenService
{
    Task<string> GenerateAccessTokenAsync(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
