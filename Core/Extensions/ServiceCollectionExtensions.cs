
using Core.Utilities.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddDependencyResolvers(this IServiceCollection services, List<ICoreModule> modules)
    {
        modules.ForEach(module =>
        {
            module.Load(services);
        });
    }
}
