using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Abstract;

namespace Core.DataAccess.Abstract
{
   public interface IEntityRepository<T> where T:class,IEntity,new()
   {
       T Get(int id);

       List<T> GetList(Expression<Func<T, bool>> filter);

       T Add(T entity);

       T Update(T entity);

       T Delete(T entity);
   }
}
