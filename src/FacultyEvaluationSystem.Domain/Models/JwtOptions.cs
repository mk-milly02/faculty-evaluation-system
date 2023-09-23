using System.ComponentModel.DataAnnotations;

namespace FacultyEvaluationSystem.Domain;

public class JwtOptions
{
    [Required]
    public string? Issuer { get; set; }

    [Required]
    public string? Audience { get; set; }

    [Required]
    public string? SecretKey { get; set; }
}
