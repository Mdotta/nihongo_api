using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Extensions;
using Api.Routes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);



builder
    .AddCorsPolicy()
    .AddAuth()
    .InjectServices();

builder.AddDocumentation();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowReactApp");

// Usar autenticação e autorização
app.UseAuth();

// Adicionar documentação apenas em desenvolvimento
if (app.Environment.IsDevelopment())
    app.UseDocumentation();

// Endpoint de login
app.MapAuthRoutes();


app.MapGet("/", () => "Hello World!");
app.Run();

//TODO: Criar config de authentication no appsettings.json
//TODO: Implementar refresh token
//TODO: Implementar logout
//TODO: Implementar infra(Repository, UnitOfWork, Migrations) - Usar PostgreSQL
//TODO: Criar Models - User, Role, UserRole, Leaderboard
//TODO: Criar Services (CQRS)
//TODO: Criar testes
//TODO: Implementar Controllers/Routes