namespace FacultyEvaluationSystem.Domain;

public class Question
{
    public Guid QuestionId { get; set; }
    public string? Text { get; set; }

    public Guid FormId { get; set; }
    public Form? Form { get; set; }
}
