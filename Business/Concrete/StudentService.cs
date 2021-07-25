using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Validation;
using Caching.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class StudentService:IStudentService
   {
       private IStudentDal _studentDal;
       private ICacheService _cacheService;

       public StudentService(IStudentDal studentDal, ICacheService cacheService)
       {
           _studentDal = studentDal;
           _cacheService = cacheService;
       }


       public Student Add(Student entity)
       {
           StudentValidator validator=new StudentValidator();
         var result= validator.Validate(entity);

         if (result.IsValid)
         {
             _cacheService.Delete("studentList");
            return _studentDal.Add(entity);
         }

         else
         {
             throw new Exception(result.Errors[0].ErrorMessage);
         }
       }

        public Student Get(int id)
        {
            return _studentDal.GetWithDepartment(id);
        }

        public void Remove(Student entity)
        {
            _cacheService.Delete("studentList");
            _studentDal.Delete(entity);
        }

        public void Update(Student entity)
        {
            _cacheService.Delete("studentList");
            _studentDal.Update(entity);
        }

        public List<Student> GetList(Expression<Func<Student, bool>> filter = null)
        {
            if (_cacheService.KeyExists("studentList"))
            {
                var dataFromRedisCache = _cacheService.Get<List<Student>>("studentList");
                return dataFromRedisCache;
            }

            else
            {
                var studentListFromDb = _studentDal.GetListWithDepartment(filter).ToList();

                _cacheService.Set<List<Student>>("studentList", studentListFromDb);


                return studentListFromDb;
            }
            
        }
    }
}
