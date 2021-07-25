using System;
using Caching.Abstract;

namespace Caching.Concrete.RedisCache
{
    public class RedisCacheService:ICacheService
    {
        public bool KeyExists(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T data)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
    }
}
