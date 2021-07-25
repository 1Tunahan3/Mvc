using System.Collections.Generic;
using Entities.Concrete;


namespace DataAccess.Abstract
{
   public interface IUserDal:IDbService<User>
   {
       public User GetUserByEmailAndPassword(string email, string password);

       public List<OperationClaim> GetUserOpeaClaims(int userId);
   }
}
