using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace MvcW03.Security
{
    public class AuthHelper
    {
        private IUserDal _userDal;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthHelper(IUserDal userDal, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _userDal = userDal;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims=new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,user.Email));
            claims.Add(new Claim(ClaimTypes.Email,user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,$"{user.FirstName} {user.LastName}"));

            var operationClaims = _userDal.GetUserOpeaClaims(user.Id);

            foreach (var claim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role,claim.Name));
            }

            return claims;
        }

        public async Task<bool> SecureSignIn(string userName, string password)
        {
            var user = _userDal.GetUserByEmailAndPassword(userName, password);
            if (user!=null)
            {
                var claims = GetClaims(user);

                var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                var principal=new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal);

                return true;
            }

            return false;
        }

        public async Task SignOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
