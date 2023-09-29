using System.ComponentModel.DataAnnotations;

namespace FacultyEvaluationSystem.Domain;

public class ApplicationUserOptions
{
    [Required(ErrorMessage = "DefaultPassword is required")]
    [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[\\d])(?=.*[\\W_)]).{8,}$",
    ErrorMessage = "The default password must contain at least eight characters, an uppercase letter, a lowercase letter, a number and a special character")]
    public string? DefaultPassword { get; set; }
}
