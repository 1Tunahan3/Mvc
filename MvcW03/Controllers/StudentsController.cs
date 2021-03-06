using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using MvcW03.Utilities;

namespace MvcW03.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentsController : Controller
    {
        // private readonly SchoolContext _studentDal;

        //private readonly IStudentService _studentService;
        //private readonly IDepartmentService _departmentService;
        private WebApiHelper _webApiHelper;
        
        

        public StudentsController( WebApiHelper webApiHelper)
        {
            
            
            _webApiHelper = webApiHelper;
        }

        // GET: Students,
        [HttpGet]
        public IActionResult Index()
        {

            var studentListFromDb = _webApiHelper.Read<List<Student>>("Students", "GetList", null);

                return View(studentListFromDb);
            


        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var student = _webApiHelper.Read<Student>("Students", "Get", id.ToString());


            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _webApiHelper.Read<List<Department>>("Departments", "GetList", null);

            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {

            var file = Request.Form.Files[0];

            student.PhotoPath = UploadPhoto(file);

            
                _webApiHelper.Modify<Student>("Students","Add",student);

                return RedirectToAction(nameof(Index));

            //    var departments = _webApiHelper.Read<List<Department>>("Departments", "GetList", null);

            //ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", student.DepartmentId);
            
        }

        private string UploadPhoto(IFormFile file)
        {
            var path = $"wwwroot/images/studentPhotos";
            var fullPath = string.Empty;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileNameGuid = Guid.NewGuid().ToString();

            fullPath = Path.Combine(path, $"{fileNameGuid}{Path.GetExtension(file.FileName)}");

            if (file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);

                    using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);

                        fileStream.Flush();
                    }
                }
            }

            return fullPath.Replace("wwwroot", "");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var student = _webApiHelper.Read<Student>("Students", "Get", id.ToString());

            var departments = _webApiHelper.Read<List<Department>>("Departments", "GetList", null);

            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name",student.DepartmentId);

         
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {

            _webApiHelper.Modify<Student>("Students", "Update", student);

            //    var departments = _webApiHelper.Read<List<Department>>("Departments", "GetList", null);

            //ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", student.DepartmentId);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _webApiHelper.Read<Student>("Students", "Get", id.ToString());
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _webApiHelper.Read<Student>("Students", "Get", id.ToString());
            _webApiHelper.Modify<Student>("Students", "Delete", student);

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return(_webApiHelper.Read<Student>("Students", "Get", id.ToString())) != null;
        }
    }




    //Redis Cache

    //public class StudentsController : Controller
    //{
    //    // private readonly SchoolContext _studentDal;

    //    private readonly IStudentDal _studentDal;
    //    private readonly IDepartmentDal _departmentDal;

    //    ConnectionMultiplexer _redisConnection=ConnectionMultiplexer.Connect("127.0.0.1:6379");
    //    private IDatabase _redisDatabase;

    //    public StudentsController(IStudentDal studentDal, IDepartmentDal departmentDal, IMemoryCache memoryCache)
    //    {
    //        _studentDal = studentDal;
    //        _departmentDal = departmentDal;
    //        _redisDatabase = _redisConnection.GetDatabase(0);
    //    }

    //    // GET: Students,
    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        if (_redisDatabase.KeyExists("studentList"))
    //        {
    //            var jsonStringData = _redisDatabase.StringGet("studentList");
    //         var dataFromRedisCache = JsonSerializer.Deserialize<List<Student>>(jsonStringData);
    //         return View(dataFromRedisCache);
    //        }

    //        else
    //        {
    //            var studentListFromDb = _studentDal.GetList();
    //            var jsonString = JsonSerializer.Serialize(studentListFromDb);
    //            _redisDatabase.StringSet("studentList", jsonString);

    //            return View(studentListFromDb);
    //        }



    //    }

    //    [HttpGet]
    //    public IActionResult Details(int id)
    //    {

    //        var student = _studentDal.Get(id);


    //        return View(student);
    //    }

    //    [HttpGet]
    //    public IActionResult Create()
    //    {
    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name");
    //        return View();
    //    }


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create(Student student)
    //    {

    //        var file = Request.Form.Files[0];

    //        student.PhotoPath = UploadPhoto(file);

    //        if (ModelState.IsValid)
    //        {
    //            _studentDal.Add(student);

    //            _redisDatabase.KeyDelete("studentList");

    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
    //        return View(student);
    //    }

    //    private string UploadPhoto(IFormFile file)
    //    {
    //        var path = $"wwwroot/images/studentPhotos";
    //        var fullPath = string.Empty;

    //        if (!Directory.Exists(path))
    //            Directory.CreateDirectory(path);

    //        var fileNameGuid = Guid.NewGuid().ToString();

    //        fullPath = Path.Combine(path, $"{fileNameGuid}{Path.GetExtension(file.FileName)}");

    //        if (file.Length > 0)
    //        {
    //            using (var memoryStream = new MemoryStream())
    //            {
    //                file.CopyTo(memoryStream);

    //                using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
    //                {
    //                    memoryStream.Seek(0, SeekOrigin.Begin);
    //                    memoryStream.CopyTo(fileStream);

    //                    fileStream.Flush();
    //                }
    //            }
    //        }

    //        return fullPath.Replace("wwwroot", "");

    //    }

    //    [HttpGet]
    //    public IActionResult Edit(int id)
    //    {

    //        var student = _studentDal.Get(id);

    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
    //        return View(student);
    //    }


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Edit(Student student)
    //    {


    //        if (ModelState.IsValid)
    //        {

    //            _studentDal.Update(student);
    //            _redisDatabase.KeyDelete("studentList");

    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
    //        return View(student);
    //    }

    //    [HttpGet]
    //    public IActionResult Delete(int id)
    //    {
    //        var student = _studentDal.Get(id);
    //        return View(student);
    //    }

    //    // POST: Students/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult DeleteConfirmed(int id)
    //    {
    //        var student = _studentDal.Get(id);
    //        _studentDal.Remove(student);

    //        _redisDatabase.KeyDelete("studentList");
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool StudentExists(int id)
    //    {
    //        return _studentDal.Get(id) != null;
    //    }
    //}









    //MEMORY CACHE
    //public class StudentsController : Controller
    //{
    //   // private readonly SchoolContext _studentDal;

    //   private readonly IStudentDal _studentDal;
    //   private readonly IDepartmentDal _departmentDal;
    //   private readonly IMemoryCache _memoryCache;


    //    public StudentsController( IStudentDal studentDal, IDepartmentDal departmentDal, IMemoryCache memoryCache)
    //    {
    //        _studentDal = studentDal;
    //        _departmentDal = departmentDal;
    //        _memoryCache = memoryCache;
    //    }

    //    // GET: Students,
    //    [HttpGet]
    //    public IActionResult Index()
    //    {

    //        var dataFromMemoryCache = _memoryCache.Get<List<Student>>("studentList");
    //        if (dataFromMemoryCache != null)
    //        {
    //            return View(dataFromMemoryCache);
    //        }
    //        else
    //        {
    //             var studentListFromDb = _studentDal.GetList();
    //             _memoryCache.Set("studentList", studentListFromDb);

    //                    return View(studentListFromDb);
    //        }



    //    }

    //    [HttpGet]
    //    public IActionResult Details(int id)
    //    {

    //        var student = _studentDal.Get(id);


    //        return View(student);
    //    }

    //    [HttpGet]
    //    public IActionResult Create()
    //    {
    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name");
    //        return View();
    //    }


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public  IActionResult Create( Student student)
    //    {

    //        var file = Request.Form.Files[0];

    //        student.PhotoPath = UploadPhoto(file);

    //        if (ModelState.IsValid)
    //        {
    //            _studentDal.Add(student);

    //           _memoryCache.Remove("studentList")

    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
    //        return View(student);
    //    }

    //    private string UploadPhoto(IFormFile file)
    //    {
    //        var path = $"wwwroot/images/studentPhotos";
    //        var fullPath = string.Empty;

    //        if (!Directory.Exists(path))
    //            Directory.CreateDirectory(path);

    //        var fileNameGuid = Guid.NewGuid().ToString();

    //        fullPath =Path.Combine(path,$"{fileNameGuid}{Path.GetExtension(file.FileName)}") ;

    //        if (file.Length>0)
    //        {
    //            using (var memoryStream=new MemoryStream())
    //            {
    //                file.CopyTo(memoryStream);

    //                using (var fileStream=new FileStream(fullPath,FileMode.OpenOrCreate))
    //                {
    //                    memoryStream.Seek(0, SeekOrigin.Begin);
    //                    memoryStream.CopyTo(fileStream);

    //                    fileStream.Flush();
    //                }
    //            }
    //        }

    //        return fullPath.Replace("wwwroot","");

    //    }

    //   [HttpGet]
    //    public IActionResult Edit(int id)
    //    {

    //        var student = _studentDal.Get(id);

    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
    //        return View(student);
    //    }


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public  IActionResult Edit( Student student)
    //    {


    //        if (ModelState.IsValid)
    //        {

    //                _studentDal.Update(student);
    //           _memoryCache.Remove("studentList")

    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
    //        return View(student);
    //    }

    //    [HttpGet]
    //    public IActionResult Delete(int id)
    //    {
    //        var student = _studentDal.Get(id);
    //        return View(student);
    //    }

    //    // POST: Students/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult DeleteConfirmed(int id)
    //    {
    //        var student = _studentDal.Get(id);
    //        _studentDal.Remove(student);

    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool StudentExists(int id)
    //    {
    //        return _studentDal.Get(id) != null;
    //    }
    //}




}
