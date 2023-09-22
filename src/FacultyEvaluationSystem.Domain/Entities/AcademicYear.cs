namespace FacultyEvaluationSystem.Domain;

public class AcademicYear
{
    public Guid AcademicYearId { get; set; }
    public string? Year { get; set; }
    public int Semester { get; set; }
    public bool IsDefault { get; set; }
    public YearStatus Status { get; set; }

    public IEnumerable<Form>? Forms { get; set; }
}
