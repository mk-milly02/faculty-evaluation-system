namespace FacultyEvaluationSystem.Domain;

public class AcademicYear
{
    public Guid AcademicYearId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Semester { get; set; }
    public bool IsDefault { get; set; }
    public YearStatus Status { get; set; }

    public ICollection<Form>? Forms { get; set; }
}
