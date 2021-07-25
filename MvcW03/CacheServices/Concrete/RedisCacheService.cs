using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcW03.CacheServices.Abstract;

namespace MvcW03.CacheServices.Concrete
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
