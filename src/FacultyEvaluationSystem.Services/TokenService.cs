using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FacultyEvaluationSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FacultyEvaluationSystem.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<User> _userManager;

    public TokenService(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<string> GenerateAccessTokenAsync(User user)
    {
        byte[] secretKeyBytes = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey!);
        SymmetricSecurityKey symmetricSecurityKey = new(secretKeyBytes);
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

        IList<string>? userRoles = await _userManager.GetRolesAsync(user);

        List<Claim> claims = new()
        {
            new Claim(JwtRegisteredClaimNames.Iss, _jwtOptions.Issuer!),
            new Claim(JwtRegisteredClaimNames.Aud, _jwtOptions.Audience!),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!),
            new Claim(ClaimTypes.Role, userRoles.First())
        };

        JwtSecurityToken securityToken = new(_jwtOptions.Issuer!,
                                             _jwtOptions.Audience!,
                                             claims,
                                             expires: DateTime.UtcNow.AddMinutes(5),
                                             signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateRefreshToken()
    {
        return Security.GenerateRandomNumber(64);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        TokenValidationParameters parameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,

            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey!))
        };

        ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, parameters, out SecurityToken securityToken);
        JwtSecurityToken jwt = (JwtSecurityToken)securityToken;
        if (jwt is null || jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.Ordinal))
        {
            throw new SecurityTokenException("Invalid JWT token");
        }

        return principal;
    }
}
