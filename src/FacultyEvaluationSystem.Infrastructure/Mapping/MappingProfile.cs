using AutoMapper;
using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, UserResponse>();
        CreateMap<CreateStudentRequest, User>();
        CreateMap<CreateStudentRequest, Student>();
        CreateMap<Student, StudentResponse>();
    }
}