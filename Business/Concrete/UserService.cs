using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
  public  class UserService:IUserService
  {
      private IUserDal userDal;

      public UserService(IUserDal userDal)
      {
          this.userDal = userDal;
      }


      public User Get(int id)
      {
          return userDal.Get(id);
      }

        public User Add(User entity)
        {
            return userDal.Add(entity);
        }

        public void Update(User entity)
        {
            userDal.Update(entity);
        }

        public void Remove(User entity)
        {
            userDal.Remove(entity);
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            return userDal.GetList(filter);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return userDal.GetUserByEmailAndPassword(email, password);
        }

        public List<OperationClaim> GetUserOpeaClaims(int userId)
        {
            return userDal.GetUserOpeaClaims(userId);
        }
    }
}
