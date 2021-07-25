using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class StudentService:IStudentService
   {
       private IStudentDal _studentDal;

       public StudentService(IStudentDal studentDal)
       {
           _studentDal = studentDal;
       }


       public Student Add(Student entity)
       {
           return _studentDal.Add(entity);
       }

        public Student Get(int id)
        {
            return _studentDal.Get(id);
        }

        public void Remove(Student entity)
        {
            _studentDal.Remove(entity);
        }

        public void Update(Student entity)
        {
            _studentDal.Update(entity);
        }

        public List<Student> GetList(Expression<Func<Student, bool>> filter = null)
        {
            return _studentDal.GetList(filter);
        }
    }
}
