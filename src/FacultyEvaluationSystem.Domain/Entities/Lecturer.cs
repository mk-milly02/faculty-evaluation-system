namespace FacultyEvaluationSystem.Domain;

public class Lecturer
{
    public Guid LectureId { get; set; }

    //navigation properties
    public User? User { get; private set; }
    public Department? Department { get; private set; }
    public ICollection<Course>? Courses { get; set; }
}
