﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IStudentService
    {
         Student Add(Student entity);

         Student Get(int id);

         void Remove(Student entity);

         void Update(Student entity);

         List<Student> GetList(Expression<Func<Student, bool>> filter = null);


    }
}
