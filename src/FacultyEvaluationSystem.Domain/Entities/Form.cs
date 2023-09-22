namespace FacultyEvaluationSystem.Domain;

public class Form
{
    public Guid FormId { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid CourseId { get; set; }
    public Course? Course { get; set; }

    public Guid AcademicYearId { get; set; }
    public AcademicYear? AcademicYear { get; set; }

    public IEnumerable<Question>? Questions { get; set; }
}
