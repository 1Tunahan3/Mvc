using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace MvcW03.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly DepartmentDal _departmentDal;

        //public DepartmentsController()
        //{
        //    _departmentDal = new DepartmentDal();
        //}
        private readonly IDepartmentService _departmentService;


        public DepartmentsController(IDepartmentDal departmentDal, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departmentList = _departmentService.GetList();
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
            _departmentService.Add(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentService.Get(id);
            return View(department);
        }


        [HttpPost]
        public IActionResult Delete(Department model)
        {
            _departmentService.Remove(model);
            return RedirectToAction("Index");
        }
    }
}
