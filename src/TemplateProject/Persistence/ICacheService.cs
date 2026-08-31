using System.Collections.Generic;

namespace TemplateProject.Persistence;

public interface ICacheService
{
    T Get<T>(string key);
    void Set<T>(string key, T value);
    void Remove(string key);
}
