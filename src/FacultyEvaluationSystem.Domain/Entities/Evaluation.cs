namespace FacultyEvaluationSystem.Domain;

public class Evaluation
{
    public Guid EvaluationId { get; set; }
    public DateTime EvaluationDate { get; set; }

    public Student? Student { get; private set; }
    public Form? Form { get; private set; }
}
