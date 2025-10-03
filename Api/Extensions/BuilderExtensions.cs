using Api.Services.Utils;
using Api.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder builder)
    {
        // Configurar CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp", policy =>
            {
                policy.WithOrigins("https://seu-dominio-react.com")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
        return builder;
    }

    public static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
        /// Configurar autenticação com JWT
        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        builder.Services.AddAuthorization();

        return builder;
    }

    public static WebApplicationBuilder AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        return builder;
    }

    public static WebApplicationBuilder InjectServices(this WebApplicationBuilder builder)
    {
        // Injetar dependências de serviços

        // Bind Settings to appsettings
        var settings = new Settings();
        builder.Configuration.GetSection("Jwt").Bind(settings.Jwt);
        builder.Services.AddSingleton(settings);

        builder.Services.AddScoped<JWTService>();
        return builder;
    }
}
