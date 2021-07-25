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
    public class UserDal:IUserDal
    {
        public User Add(User entity)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }

            return entity;
        }

        public User Get(int id)
        {
            using (SchoolContext context = new SchoolContext())
            {
                return context.Set<User>().FirstOrDefault(p => p.Id == id);
            }
        }

        public void Remove(User entity)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            using (SchoolContext context = new SchoolContext())
            {
                return filter == null
                    ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();


            }
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (SchoolContext context = new SchoolContext())
            {
                return context.Set<User>().FirstOrDefault(p => p.Email == email && p.Password == password);


            }
        }

        public List<OperationClaim> GetUserOpeaClaims(int userId)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var claims = from p in context.UserOperationClaims
                    where p.UserId == userId
                    select new OperationClaim()
                    {
                        Id = p.OperationClaimId,
                        Name = p.OperationClaim.Name
                    };
                return claims.ToList();


            }
        }
    }
}
