using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MvcW03.DataAccess
{
  public  interface IDbService<T> where T:class,new()
    {
        T Add(T entity);

        T Get(int id);

        void Remove(T entity);

        void Update(T entity);

        List<T> GetList(Expression<Func<T,bool>> filter=null);

    }
}
