using Api.DTOs.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Routes;

public static class AuthRoutes
{
    public static void MapAuthRoutes(this WebApplication app)
    {
        var configuration = app.Services.GetRequiredService<IConfiguration>();

        // Endpoint de login
        app.MapPost("/login", (LoginRequest request) =>
        {
            // Valide o usuário (substitua por sua lógica de validação)
            if (request.Username == "admin" && request.Password == "password")
            {
                var jwtSettings = configuration.GetSection("Jwt");
                var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, request.Username) }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = jwtSettings["Issuer"],
                    Audience = jwtSettings["Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Results.Ok(new { Token = tokenHandler.WriteToken(token) });
            }

            return Results.Unauthorized();
        });
    }
}
