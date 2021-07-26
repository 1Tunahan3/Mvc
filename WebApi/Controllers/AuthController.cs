using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using WebApi.Security.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private ITokenHandler _tokenHandler;

        public AuthController(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = _userService.GetUserByEmailAndPassword(userLogin.Email, userLogin.Password);
            if (user!=null)
            {
                var accesstoken = _tokenHandler.CreateAccessToken(user);

                return Ok(accesstoken);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
