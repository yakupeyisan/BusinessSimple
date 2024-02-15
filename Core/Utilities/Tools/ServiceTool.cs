using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Tools;
public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; set; }

    public static void CreateServiceProvider(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
    }

    public static T GetService<T>() => ServiceProvider.GetService<T>() ?? throw new Exception("Service not found => "+typeof(T).Name);

    public static object GetService(Type type)
    {
        return ServiceProvider.GetService(type) ?? throw new Exception("Service not found");
    }

}
