using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcW03.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework.Contexts;


namespace MvcW03.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext context;

        public HomeController()
        {
            this.context=new SchoolContext();
        }

        public IActionResult Index()
        {
            var departmentList = context.Departments.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
