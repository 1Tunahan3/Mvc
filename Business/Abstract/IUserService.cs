using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IUserService
  {
      User Get(int id);

      User Add(User entity);

       User Update(User entity);

      User Remove(User entity);

      public List<User> GetList(Expression<Func<User, bool>> filter = null);

      public User GetUserByEmailAndPassword(string email, string password);

      public List<OperationClaim> GetUserOpeaClaims(int userId);

  }
}
