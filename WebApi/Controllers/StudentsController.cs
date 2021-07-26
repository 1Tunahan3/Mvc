using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "student")]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetList")]
        public IActionResult Index()
        {
            var departments = _studentService.GetList();
            return Ok(departments);

        }



        [HttpGet("Get")]
        public IActionResult Get(int filter)
        {

            var department = _studentService.Get(filter);


            return Ok(department);
        }


        [HttpPost("Add")]
        public IActionResult Add(Student entity)
        {

            var student = _studentService.Add(entity);


            return Ok(student);
        }


        [HttpPost("Update")]
        public IActionResult Update(Student entity)
        {

            var student = _studentService.Update(entity);


            return Ok(student);
        }



        [HttpPost("Delete")]
        public IActionResult Delete(Student entity)
        {

            var student = _studentService.Remove(entity);

            return Ok(student);
        }

    }
}
