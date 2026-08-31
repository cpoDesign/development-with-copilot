using System.Collections.Generic;

namespace TemplateProject.Persistence;

public class InMemoryCacheService : ICacheService
{
    private readonly Dictionary<string, object> _cache = new();

    public T Get<T>(string key) => _cache.TryGetValue(key, out var value) ? (T)value : default;

    public void Set<T>(string key, T value) => _cache[key] = value;

    public void Remove(string key) => _cache.Remove(key);
}
