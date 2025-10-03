namespace Api.Models;

public sealed record AuthToken
{
    public string Token { get; init; }
    public DateTime ExpiredAfter { get; init; }
    public AuthToken(string token,DateTime expiredAfter)
    {
        Token = token;
        ExpiredAfter = expiredAfter;
    }
}
