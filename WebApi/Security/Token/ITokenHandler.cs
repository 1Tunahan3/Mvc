using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebApi.Security.Token
{
  public  interface ITokenHandler
  {
      AccessToken CreateAccessToken(User user);

      void RefreshToken(User user);

  }
}
