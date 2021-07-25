using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Abstract
{
  public  interface IStudentDal:IEntityRepository<Student>
  {
      public Student GetWithDepartment(int id);

      public List<Student> GetListWithDepartment(Expression<Func<Student, bool>> filter);
  }
}
