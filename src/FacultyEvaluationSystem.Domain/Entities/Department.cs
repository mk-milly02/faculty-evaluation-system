namespace FacultyEvaluationSystem.Domain;

public class Department
{
    public Guid DepartmentId { get; set; }
    public string? Name { get; set; }
 
    public User? DepartmentHead { get; private set; }
    public ICollection<Student>? Students { get; set; }
    public ICollection<Lecturer>? Lecturers { get; set; }
    public ICollection<Course>? Courses { get; set; }
}
