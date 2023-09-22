using Microsoft.AspNetCore.Identity;

namespace FacultyEvaluationSystem.Domain;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PasswordSalt { get; set; }
}