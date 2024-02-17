using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Tools;

namespace Core.Aspects.Autofac.Caching;
public class CacheRemoveAspect : MethodInterception
{
    private readonly ICacheService _cacheService;
    private string _key;
    public string[] Parameters { get; set; } = [];
    public CacheRemoveAspect(string key)
    {
        _key = key;
        _cacheService = ServiceTool.GetService<ICacheService>();
    }


    protected override void OnSuccess(IInvocation invocation)
    {
        string key = _key;
        string GetValue(string type,string prop)
        {
            var obj = invocation.Arguments.Where(a=>a.GetType().Name==type)?.FirstOrDefault();
            if (obj != null)
            {
                var value=obj.GetType().GetProperties().Where(e => e.Name == prop)?.FirstOrDefault()?.GetValue(obj)?.ToString();
                return value??"";
            }
            return "";
        }
        if (Parameters.Length > 0)
        {
            var appendKey=string.Join(',',Parameters.ToList().Select(parameter =>
            {
                var values = parameter.Split('.');
                return GetValue(values[0], values[1]);
            }));
            key += "|"+appendKey;
        }
        _cacheService.Remove(key);

    }
}