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
    public class UserDal:EfEntityRepositoryBase<User,SchoolContext>,IUserDal
    {

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
