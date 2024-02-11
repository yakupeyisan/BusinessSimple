using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Core.CrossCuttingConcerns.Caching.Custom;

public static class CacheData
{
    public static IDictionary<string, object> CachedResults = new Dictionary<string, object>();
}
public class CustomCacheManager : ICacheService
{

    public void Add(string key, object value, int duration)
    {
        if (this.IsAdd(key))
        {
            CacheData.CachedResults[key] = value;
            return;
        }
        CacheData.CachedResults.Add(key, value);
    }

    public object Get(string key)
    {
        if(this.IsAdd(key))
            return CacheData.CachedResults[key];
        return default;
    }

    public T Get<T>(string key)
    {
        return (T)this.Get(key);
    }

    public bool IsAdd(string key)
    {
       return CacheData.CachedResults.ContainsKey(key);
    }

    public void Remove(string key)
    {
        if(this.IsAdd(key))
            CacheData.CachedResults.Remove(key);
    }
}
