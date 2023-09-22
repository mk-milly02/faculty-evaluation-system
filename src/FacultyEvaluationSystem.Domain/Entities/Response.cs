namespace FacultyEvaluationSystem.Domain;

public class Response
{
    public Guid ResponseId { get; set; }
    public int Rating { get; set; }

    public Question? Question { get; private set; }
}
