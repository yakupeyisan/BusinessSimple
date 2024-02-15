using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Tools;

namespace Core.Aspects.Autofac.Caching;

public class CacheAspect : MethodInterception
{
    private int _duration;

    private readonly ICacheService _cacheService;
    public CacheAspect(int duration = 30)
    {
        _cacheService = ServiceTool.GetService<ICacheService>();
        _duration = duration;
    }


    public override void Intercept(IInvocation invocation)
    {
        string key = invocation.Method.ReflectedType.FullName + "." + invocation.Method.Name;
        if (_cacheService.IsAdd(key))
        {
            invocation.ReturnValue = _cacheService.Get(key);
            return;
        }
        invocation.Proceed();
        _cacheService.Add(key, invocation.ReturnValue,_duration);

    }
}