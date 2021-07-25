using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IDepartmentService
   {
        Department Add(Department entity);

        Department Get(int id);


        void Remove(Department entity);


        void Update(Department entity);


        List<Department> GetList(Expression<Func<Department, bool>> filter = null);

   }
}
