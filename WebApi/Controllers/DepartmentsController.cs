using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IStudentService _studentService;
        private IDepartmentService _departmentService;

        public DepartmentsController(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        [HttpGet("GetList")]
        public IActionResult Index()
        {
            var studentListFromDb = _departmentService.GetList();
            return Ok(studentListFromDb);

        }



        [HttpGet("Get")]
        public IActionResult Get(int filter)
        {

            var student = _departmentService.Get(filter);


            return Ok(student);
        }
    }
}
