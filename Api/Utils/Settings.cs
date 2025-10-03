namespace Api.Utils;

public class Settings
{
    public JwtSettings Jwt { get; set; }
}
public class JwtSettings
{
    public string JwtKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpireMinutes { get; set; }
}