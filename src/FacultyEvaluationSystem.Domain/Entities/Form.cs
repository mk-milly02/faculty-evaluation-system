namespace FacultyEvaluationSystem.Domain;

public class Form
{
    public Guid FormId { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Course? Course { get; private set; }
    public AcademicYear? AcademicYear { get; private set; }
    public ICollection<Question>? Questions { get; set; }
}
