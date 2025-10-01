using Scalar.AspNetCore;

namespace Api.Extensions;

public static class AppExtensions
{

    public static WebApplication UseAuth(this WebApplication app)
    {
        // Usar autenticação e autorização
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Title = "My API";
            options.DarkMode = true;
        });
        return app;
    }
}
