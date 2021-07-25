using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.DalLayers
{
    public class StudentDal:EfEntityRepositoryBase<Student,SchoolContext>,IStudentDal
    {
        public Student GetWithDepartment(int id)
        {
            using (SchoolContext context=new SchoolContext())
            {
                return context.Set<Student>().Include("Department").FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Student> GetListWithDepartment(Expression<Func<Student, bool>> filter)
        {
            using (SchoolContext context = new SchoolContext())
            {
                return filter == null
                    ? context.Set<Student>().Include("Department").ToList()
                    : context.Set<Student>().Include("Department").Where(filter).ToList();
            }
        }
    }
}
