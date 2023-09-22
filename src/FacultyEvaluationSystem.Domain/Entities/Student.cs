namespace FacultyEvaluationSystem.Domain;

public class Student
{
    public Guid StudentId { get; set; }
    public string? IndexNumber { get; set; }
    public Year Year { get; set; }
    public DateTime GraduationYear { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public IEnumerable<Course>? Courses { get; set; }
}
