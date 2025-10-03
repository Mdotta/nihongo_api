using Api.Models;
using Api.Services.Utils;
using ErrorOr;
using MediatR;

namespace Api.Handlers.Authentication.Command.Authenticate;

public class AuthenticateHandler(JWTService jwtService) : IRequestHandler<AuthenticateCommand, ErrorOr<Success>>
{
    public Task<ErrorOr<Success>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var token = jwtService.GenerateToken(new User
            {
                Id = 1,
                Username = request.Username,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
        }catch(Exception ex)
        {
            return Task.FromResult<ErrorOr<Success>>(Error.Failure(code:"Authentication.Failure",ex.Message));
        }
        //TODO: validar usuário via repositório
        return Task.FromResult<ErrorOr<Success>>(Result.Success);
    }
}
