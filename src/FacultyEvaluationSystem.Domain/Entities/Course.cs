namespace FacultyEvaluationSystem.Domain;

public class Course
{
    public Guid CourseId { get; set; }
    public string? CourseCode { get; set; }
    public string? Name { get; set; }
    
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public Guid LeecturerId { get; set; }
    public Lecturer? Lecturer { get; set; }
}
