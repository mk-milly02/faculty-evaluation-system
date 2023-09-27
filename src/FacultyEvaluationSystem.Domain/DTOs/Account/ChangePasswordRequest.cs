using System.ComponentModel.DataAnnotations;

namespace FacultyEvaluationSystem.Domain;

public class ChangePasswordRequest
{
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[\\d])(?=.*[\\W_)]).{8,}$",
    ErrorMessage = "The password must contain at least eight characters, an uppercase letter, a lowercase letter, a number and a special character")]
    public string? Password { get; set; }

    [Required, Compare(nameof(Password), ErrorMessage = "The password and confirmation entered do not match")]
    public string? Confirmation { get; set; }
}
