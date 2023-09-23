using System.Text;
using FacultyEvaluationSystem.Domain;
using FacultyEvaluationSystem.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FacultyEvaluationSystem.Services;

public static class DependencyInjectionExtensions
{
    public static void ConfigureOptions(this IServiceCollection services)
    {
        services.AddOptions<JwtOptions>()
                .BindConfiguration(nameof(JwtOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<ITokenService, TokenService>();
    }

    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Default")
                                  ?? throw new NullReferenceException("Connection string not configured.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        
        services.AddIdentity<User, Role>(options =>
        {
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@ ";
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
    }

    public static void AddJwtAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey!))
            };
        });
    }
}
