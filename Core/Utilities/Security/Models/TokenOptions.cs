namespace Core.Utilities.Security.Models;

public class TokenOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecurityKey { get; set; }
    public int ExpirationMinute { get; set; }
}
