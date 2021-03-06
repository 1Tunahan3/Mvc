using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
  public  class DepartmentService:IDepartmentService
  {
      private IDepartmentDal _departmentDal;

      public DepartmentService(IDepartmentDal departmentDal)
      {
          _departmentDal = departmentDal;
      }

      public Department Add(Department entity)
      {
          return _departmentDal.Add(entity);
      }

        public Department Get(int id)
        {
            return _departmentDal.Get(id);
        }

        public Department Remove(Department entity)
        {
          return _departmentDal.Delete(entity);
        }

        public Department Update(Department entity)
        {
           return _departmentDal.Update(entity);
        }

        public List<Department> GetList(Expression<Func<Department, bool>> filter = null)
        {
            return _departmentDal.GetList(filter);
        }
    }
}
