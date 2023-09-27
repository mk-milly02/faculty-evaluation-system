using AutoMapper;
using FacultyEvaluationSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FacultyEvaluationSystem.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly ILogger<UserService> _logger;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, ILogger<UserService> logger, IMapper mapper)
    {
        _userManager = userManager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<string?> CreateUserAsync(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        user.PasswordSalt = Security.GenerateRandomNumber(32);
        string saltedPassword = Security.GenerateSaltedPassword(request.Password!, user.PasswordSalt);

        try
        {
            await _userManager.CreateAsync(user, saltedPassword);
            await _userManager.AddToRoleAsync(user, request.Role!);
            return await _userManager.GetUserIdAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured whiles creating user.");
            return null;
        }
    }

    public async Task<UserResponse?> GetUserAsync(Guid userId)
    {
        User? user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is not null)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            UserResponse profile = _mapper.Map<UserResponse>(user);
            profile.Role = roles.First();
            return profile;
        }

        return null;
    }

    public async Task<PagedList<UserResponse>> GetAllUsers(QueryParameters parameters)
    {
        List<UserResponse> response = new();
        IEnumerable<User> users = _userManager.Users.ToList();

        foreach (User user in users)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            UserResponse profile = _mapper.Map<UserResponse>(user);
            profile.Role = roles.First();
            response.Add(profile);
        }

        return new(response, parameters.Page, parameters.Size);
    }

    public async Task<bool> UpdateUserAsync(Guid userId, UpdateUserRequest request)
    {
        User? user = await _userManager.FindByIdAsync(userId.ToString());

        user!.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.UserName = request.UserName;

        try
        {
            await _userManager.UpdateAsync(user);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured whiles editing user with id:{id}", userId);
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        User? user = await _userManager.FindByIdAsync(userId.ToString());
        try
        {
            await _userManager.DeleteAsync(user!);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured whiles deleting user with id:{id}", userId);
            return false;
        }
    }

    public Task<bool> ChangePasswordAsync(Guid userId, ChangePasswordRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> EmailAlreadyExists(string email)
    {
        User? user = await _userManager.FindByEmailAsync(email);
        return user is not null;
    }

    //confirm email
}
