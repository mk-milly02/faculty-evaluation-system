namespace FacultyEvaluationSystem.Domain;

public class StudentResponse
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? IndexNumber { get; set; }
    public Year Year { get; set; }
    public DateTime GraduationYear { get; set; }
}
