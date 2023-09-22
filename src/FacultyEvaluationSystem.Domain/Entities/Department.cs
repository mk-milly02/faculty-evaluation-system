namespace FacultyEvaluationSystem.Domain;

public class Department
{
    public Guid DepartmentId { get; set; }
    public string? Name { get; set; }
    
    public Guid DepartmentHeadId { get; set; }
    public User? DepartmentHead { get; set; }

    public IEnumerable<Student>? Students { get; set; }
    public IEnumerable<Lecturer>? Lecturers { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
}
