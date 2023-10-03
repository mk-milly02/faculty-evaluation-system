using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Services;

public interface IAccountService
{
    Task<ServiceResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
}
