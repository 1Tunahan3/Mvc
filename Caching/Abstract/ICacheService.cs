namespace Caching.Abstract
{
  public  interface ICacheService
  {
      bool KeyExists(string key);

      T Get<T>(string key);

      void Set<T>(string key, T data);

      void Delete (string key);
  }
}
