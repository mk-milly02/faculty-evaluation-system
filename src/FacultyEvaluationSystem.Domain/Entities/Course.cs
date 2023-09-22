namespace FacultyEvaluationSystem.Domain;

public class Course
{
    public Guid CourseId { get; set; }
    public string? CourseCode { get; set; }
    public string? Name { get; set; }
    
    public Department? Department { get; private set; }
    public Lecturer? Lecturer { get; private set; }
}
