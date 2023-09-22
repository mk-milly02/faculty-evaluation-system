namespace FacultyEvaluationSystem.Domain;

public class Student
{
    public Guid StudentId { get; set; }
    public string? IndexNumber { get; set; }
    public Year Year { get; set; }
    public DateTime GraduationYear { get; set; }

    //navigation properties
    public User? User { get; private set; }
    public Department? Department { get; private set; }
    public ICollection<Course>? Courses { get; set; }
}
