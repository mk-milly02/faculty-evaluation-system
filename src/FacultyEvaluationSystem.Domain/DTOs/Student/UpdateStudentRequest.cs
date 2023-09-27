using System.ComponentModel.DataAnnotations;

namespace FacultyEvaluationSystem.Domain;

public class UpdateStudentRequest
{
    [Required(ErrorMessage = "Index number is required")]
    [MaxLength(15, ErrorMessage = "Index number should not be more than 15 characters")]
    public string? IndexNumber { get; set; }

    [Required(ErrorMessage = "Year is required"), EnumDataType(typeof(Year), ErrorMessage = "Invalid year")]
    public Year Year { get; set; }

    [Required(ErrorMessage = "Graduation year is required")]
    public DateTime GraduationYear { get; set; }
}
