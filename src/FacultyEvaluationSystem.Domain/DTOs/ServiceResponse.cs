using System.Net;

namespace FacultyEvaluationSystem.Domain;

public class ServiceResponse<T> where T : class
{
    public HttpStatusCode Code { get; set; }
    public string? Message { get; set; }
    public T? Value { get; set; }
}
