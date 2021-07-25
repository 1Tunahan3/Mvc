using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.DalLayers
{
    public class StudentDal:IStudentDal
    {
        public Student Add(Student entity)
        {
            using (var context=new SchoolContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

            return entity;
        }

        public Student Get(int id)
        {
            using (var context=new SchoolContext())
            {
                return context.Set<Student>().Include("Department").FirstOrDefault(p => p.Id == id);
            }
        }

        public void Remove(Student entity)
        {
            using (var context =new SchoolContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Student entity)
        {
            using (var context=new SchoolContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Student> GetList(Expression<Func<Student,bool>> filter=null)
        {
            using (var context=new SchoolContext())
            {
                return filter == null
                    ? context.Set<Student>().Include("Department").ToList()
                    : context.Set<Student>().Include("Department").Where(filter).ToList();
            }
        }
    }
}
