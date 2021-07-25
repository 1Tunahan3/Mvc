using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MvcW03.Security;

namespace MvcW03.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private AuthHelper _authHelper;

        public AuthController(AuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult>  Login(string userName, string password)
        {
            var isSuccess = await _authHelper.SecureSignIn(userName, password);

            if (isSuccess)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _authHelper.SignOut();

            return RedirectToAction("Login");
        }


        [HttpGet]
        public async Task<IActionResult> Err()
        {
            ViewBag.Message = "Buraya giriş yetkiniz bulunmamaktadır";
            return View();
        }


    }
}
