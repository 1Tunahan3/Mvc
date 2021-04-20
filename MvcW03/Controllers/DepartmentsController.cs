using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcW03.DataAccess.DbServices;
using MvcW03.DataAccess.DbServices.Abstract;
using MvcW03.Entities;

namespace MvcW03.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly DepartmentDal _departmentDal;

        //public DepartmentsController()
        //{
        //    _departmentDal = new DepartmentDal();
        //}
        private readonly IDepartmentDal _departmentDal;

        public DepartmentsController(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public IActionResult Index()
        {
            var departmentList = _departmentDal.GetList();
            return View(departmentList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Create(Department model)
        {
            _departmentDal.Add(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentDal.Get(id);
            return View(department);
        }


        [HttpPost]
        public IActionResult Delete(Department model)
        {
            _departmentDal.Remove(model);
            return RedirectToAction("Index");
        }
    }
}
