using System.ComponentModel.DataAnnotations;

namespace FacultyEvaluationSystem.Domain;

public class CreateStudentRequest
{
    [Required(ErrorMessage = "Firstname is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Lastname is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Index number is required")]
    [MaxLength(15, ErrorMessage = "Index number should not be more than 15 characters")]
    public string? IndexNumber { get; set; }

    [Required(ErrorMessage = "Year is required"), EnumDataType(typeof(Year), ErrorMessage = "Invalid year")]
    public Year Year { get; set; }

    [Required(ErrorMessage = "Graduation year is required")]
    public DateTime GraduationYear { get; set; }
}
