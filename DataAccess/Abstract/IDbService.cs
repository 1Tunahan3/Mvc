using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
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
