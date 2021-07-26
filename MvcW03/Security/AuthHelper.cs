using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
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
        private IUserService _userService;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthHelper( IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims=new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,user.Email));
            claims.Add(new Claim(ClaimTypes.Email,user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,$"{user.FirstName} {user.LastName}"));

            var operationClaims = _userService.GetUserOpeaClaims(user.Id);

            foreach (var claim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role,claim.Name));
            }

            return claims;
        }

        public async Task<bool> SecureSignIn(string userName, string password)
        {
            var user = _userService.GetUserByEmailAndPassword(userName, password);
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
