using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcW03.CacheServices.Abstract
{
  public  interface ICacheService
  {
      bool KeyExists(string key);

      T Get<T>(string key);

      void Set<T>(string key, T data);

      void Delete (string key);
  }
}
