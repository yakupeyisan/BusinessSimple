using Castle.DynamicProxy;
using Core.Utilities.ByPass;
using Core.Utilities.Interceptors;
using Core.Utilities.Tools;
using Microsoft.AspNetCore.Http;

namespace Core.Aspects.Autofac.Security;

public class SecurityAspect : MethodInterception
{
    private string[] ExternalRoles { get; set; }
    private readonly IHttpContextAccessor Context;
    private readonly SecurityByPass SecurityByPass;

    public SecurityAspect(string[]? externalRoles = null)
    {
        Priority = -1;
        ExternalRoles = externalRoles ?? [];
        Context = ServiceTool.GetService<IHttpContextAccessor>();
        SecurityByPass = ServiceTool.GetService<SecurityByPass>();
    }
    protected override void OnBefore(IInvocation invocation)
    {
        if (SecurityByPass.ByPass)
        {
            SecurityByPass.ByPass = false;
            return;
        }
        string role = $"{invocation.Method.ReflectedType.Name}.{invocation.Method.Name}";
        var roles = ExternalRoles.ToList();
        roles.Add(role);
        roles.Add("supervisor");
        var user = Context.HttpContext.User;
        if (user.Identity.IsAuthenticated==false)
        {
            throw new AuthenticationException("You are not authentication");
        }
        var claims = user.Claims.ToList().Where(c => c.Type == System.Security.Claims.ClaimTypes.Role).Select(c => c.Value).ToList();
        if (!roles.Where(rol => claims.Contains(rol)).Any())
        {
            throw new AuthorizationException(role,"You are not authorized");
        }
    }
}