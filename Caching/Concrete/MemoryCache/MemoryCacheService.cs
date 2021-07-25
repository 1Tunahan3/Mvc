using Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Concrete.MemoryCache
{
    public class MemoryCacheService:ICacheService
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public bool KeyExists(string key)
        {
            return _memoryCache.Get(key) != null;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Set<T>(string key, T data)
        {
            _memoryCache.Set(key, data);
        }

        public void Delete (string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
