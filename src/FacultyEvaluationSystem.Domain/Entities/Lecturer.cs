namespace FacultyEvaluationSystem.Domain;

public class Lecturer
{
    public Guid LectureId { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public IEnumerable<Course>? Courses { get; set; }
}
