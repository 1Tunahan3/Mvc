using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcW03.DataAccess.DbServices.Abstract;
using MvcW03.DataAccess.EntityFramework;
using MvcW03.Entities;

namespace MvcW03.DataAccess.DbServices.Concrete
{
    public class DepartmentDal:IDepartmentDal
    {
        public Department Add(Department entity)
        {
            using (SchoolContext context=new SchoolContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }

            return entity;
        }

        public Department Get(int id)
        {
            using (SchoolContext context=new SchoolContext())
            {
                return context.Set<Department>().FirstOrDefault(p => p.Id == id);
            }
        }

        public void Remove(Department entity)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Department entity)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Department> GetList(Expression<Func<Department,bool>> filter=null)
        {
            using (SchoolContext context = new SchoolContext())
            {
                return filter == null
                    ? context.Set<Department>().ToList()
                    : context.Set<Department>().Where(filter).ToList();


            }
        }
    }
}
