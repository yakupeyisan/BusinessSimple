namespace Core.Aspects.Autofac.Security;

public class AuthenticationException : Exception
{
    public AuthenticationException(string message) : base(message)
    {
    }
}