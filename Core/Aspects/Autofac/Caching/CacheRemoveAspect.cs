using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Tools;

namespace Core.Aspects.Autofac.Caching;

public class CacheRemoveAspect : MethodInterception
{
    private readonly ICacheService _cacheService;
    private string _key;
    public CacheRemoveAspect(string key)
    {
        _key = key;
        _cacheService = ServiceTool.GetService<ICacheService>();
    }


    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheService.Remove(_key);

    }
}