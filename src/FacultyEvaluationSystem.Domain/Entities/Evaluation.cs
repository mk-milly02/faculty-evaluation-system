namespace FacultyEvaluationSystem.Domain;

public class Evaluation
{
    public Guid EvaluationId { get; set; }
    public DateTime EvaluationDate { get; set; }

    public Guid StudentId { get; set; }
    public Student? Student { get; set; }

    public Guid FormId { get; set; }
    public Form? Form { get; set; }
}
