using System.ComponentModel.DataAnnotations;

namespace FacultyEvaluationSystem.Domain;

public class QueryParameters
{
    [Required, Range(1, double.MaxValue, ErrorMessage = "The minimum page number is one")]
    public int Page { get; set; }

    public string? S { get; set; } // search term

    [Required, Range(5, 30, ErrorMessage = "Returns a minimum of 5 items and a maximum of 30 items")]
    public int Size { get; set; }
}
