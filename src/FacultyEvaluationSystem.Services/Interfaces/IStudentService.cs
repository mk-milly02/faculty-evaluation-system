using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Services;

public interface IStudentService
{
    Task<string?> CreateStudentAsync(CreateStudentRequest request);
    Task<StudentResponse?> GetStudentAsync(Guid studentId);
    Task<PagedList<StudentResponse>> GetAllStudents(QueryParameters parameters);
    Task<bool> UpdateStudentAsync(Guid studentId, UpdateStudentRequest request);
    Task<bool> DeleteStudentAsync(Guid studentId);
}
