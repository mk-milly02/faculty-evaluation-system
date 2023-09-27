using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Services;

public class StudentService : IStudentService
{
    public Task<string?> CreateStudentAsync(CreateStudentRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteStudentAsync(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<StudentResponse>> GetAllStudents(QueryParameters parameters)
    {
        throw new NotImplementedException();
    }

    public Task<StudentResponse?> GetStudentAsync(Guid studentId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateStudentAsync(Guid studentId, UpdateStudentRequest request)
    {
        throw new NotImplementedException();
    }
}
