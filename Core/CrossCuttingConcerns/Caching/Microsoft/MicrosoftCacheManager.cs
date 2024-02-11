using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft;
public class MicrosoftCacheManager : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public MicrosoftCacheManager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public void Add(string key, object value, int duration)
    {
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
    }

    public object Get(string key)
    {
       return _memoryCache.Get(key)??throw new Exception("Key not found");
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key) ?? throw new Exception("Key not found");
    }

    public bool IsAdd(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
}
