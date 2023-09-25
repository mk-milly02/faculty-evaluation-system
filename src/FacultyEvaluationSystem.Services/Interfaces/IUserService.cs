using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Services;

public interface IUserService
{
    Task<string?> CreateUserAsync(CreateUserRequest request);
    Task<UserResponse?> GetUserAsync(Guid userId);
    Task<PagedList<UserResponse>> GetAllUsers(QueryParameters parameters);
    Task<bool> UpdateUserAsync(Guid userId, UpdateUserRequest request);
    Task<bool> DeleteUserAsync(Guid userId);
}
