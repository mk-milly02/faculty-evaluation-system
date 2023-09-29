using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace FacultyEvaluationSystem.Domain;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PasswordSalt { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
    public bool ChangedDefaultPassword { get; set; }
    public override string? UserName { get => $"{FirstName}-{LastName}{RandomNumberGenerator.GetInt32(101)}"; set => base.UserName = value; }
}