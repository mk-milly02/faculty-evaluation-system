using System.Security.Cryptography;
using AutoMapper;
using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Infrastructure;

public class Username : IValueResolver<CreateUserRequest, User, string?>
{
    public string? Resolve(CreateUserRequest source, User destination, string? destMember, ResolutionContext context)
    {
        return $"{source.FirstName}-{source.LastName}{RandomNumberGenerator.GetInt32(101)}";
    }
}
