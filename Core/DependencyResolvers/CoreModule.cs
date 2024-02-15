using System.Diagnostics;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Security.JWT;
using Core.Utilities.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;
public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, MicrosoftCacheManager>();
        services.AddSingleton<ITokenHelper, JWTTokenHelper>();
        services.AddSingleton<Stopwatch>();
    }
}
