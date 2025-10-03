using Api.Models;
using Api.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services.Utils;

public class JWTService(Settings settings)
{
    public AuthToken GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.JwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Username", user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var expiresAt = DateTime.UtcNow.AddMinutes(settings.Jwt.ExpireMinutes);

        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
            issuer: settings.Jwt.Issuer,
            audience: settings.Jwt.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        var authToken= new AuthToken(
            new JwtSecurityTokenHandler().WriteToken(token),
            expiresAt
        );

        return authToken;
    }
}
