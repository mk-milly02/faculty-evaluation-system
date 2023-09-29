using AutoMapper;
using FacultyEvaluationSystem.Domain;
using FacultyEvaluationSystem.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FacultyEvaluationSystem.Services;

public class StudentService : IStudentService
{
    private readonly IMapper _mapper;
    private readonly IOptions<ApplicationUserOptions> _options;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<StudentService> _logger;
    private readonly IRepository<Student> _studentRepository;

    public StudentService(IMapper mapper,
                          IOptions<ApplicationUserOptions> options,
                          UserManager<User> userManager,
                          ILogger<StudentService> logger,
                          IRepository<Student> studentRepository)
    {
        _mapper = mapper;
        _options = options;
        _userManager = userManager;
        _logger = logger;
        _studentRepository = studentRepository;
    }

    public async Task<string?> CreateStudentAsync(CreateStudentRequest request)
    {
        User user = _mapper.Map<User>(request);
        Student student = _mapper.Map<Student>(request);
        user.PasswordSalt = Security.GenerateRandomNumber(32);
        string saltedPassword = Security.GenerateSaltedPassword(_options.Value.DefaultPassword!, user.PasswordSalt);

        try
        {
            await _userManager.CreateAsync(user, saltedPassword);
            await _userManager.AddToRoleAsync(user, nameof(Roles.Student));
            Student created = await _studentRepository.CreateAsync(student);
            return created.StudentId.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured whiles creating student.");
            return null;
        } 
    }

    public async Task<bool> DeleteStudentAsync(Guid studentId)
    {
        Student? student = await _studentRepository.RetrieveAsync(studentId);
        try
        {
            await _studentRepository.DeleteAsync(student!);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured whiles deleting student with id:{id}", studentId);
            return false;
        }
    }

    public PagedList<StudentResponse> GetAllStudents(QueryParameters parameters)
    {
        List<StudentResponse> response = new();
        IEnumerable<Student> students = _studentRepository.RetrieveAll();

        if (students is null)
        {
            return new();
        }

        foreach (Student student in students)
        {
            StudentResponse profile = _mapper.Map<StudentResponse>(student);
            response.Add(profile);
        }

        return new(response, parameters.Page, parameters.Size);
    }

    public async Task<StudentResponse?> GetStudentAsync(Guid studentId)
    {
        Student? student = await _studentRepository.RetrieveAsync(studentId);
        return student is not null ? _mapper.Map<StudentResponse>(student) : null;
    }

    public async Task<bool> UpdateStudentAsync(Guid studentId, UpdateStudentRequest request)
    {
        Student? student = await _studentRepository.RetrieveAsync(studentId);

        student!.IndexNumber = request.IndexNumber;
        student.Year = request.Year;
        student.GraduationYear = request.GraduationYear;

        try
        {
            await _studentRepository.UpdateAsync(student);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured whiles editing user with id:{id}", studentId);
            return false;
        }
    }
}
