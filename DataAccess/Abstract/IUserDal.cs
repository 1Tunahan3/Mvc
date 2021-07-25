using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
   {
       public User GetUserByEmailAndPassword(string email, string password);

       public List<OperationClaim> GetUserOpeaClaims(int userId);
   }
}
