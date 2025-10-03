using ErrorOr;
using MediatR;

namespace Api.Handlers.Authentication.Command.Authenticate;

public sealed record AuthenticateCommand:IRequest<ErrorOr<Success>>
{
    public string Username { get; init; }
    public string Password { get; init; }
    public AuthenticateCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
