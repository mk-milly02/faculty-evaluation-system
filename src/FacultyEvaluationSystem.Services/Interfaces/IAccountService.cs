using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Services;

public interface IAccountService
{
    Task<AuthenticationResponse?> AuthenticateAsync(AuthenticationRequest request);
}
