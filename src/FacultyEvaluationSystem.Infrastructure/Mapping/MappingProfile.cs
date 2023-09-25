using AutoMapper;
using FacultyEvaluationSystem.Domain;

namespace FacultyEvaluationSystem.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserRequest, User>().ForMember(x => x.UserName, opts => opts.MapFrom<Username>());
        CreateMap<User, UserResponse>();
    }
}