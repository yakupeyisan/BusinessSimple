namespace Core.Aspects.Autofac.Security;

public class AuthorizationException : Exception
{
    public string Role { get; private set; }
    public AuthorizationException(string role, string message) : base(message)
    {
        Role = role;
    }
}