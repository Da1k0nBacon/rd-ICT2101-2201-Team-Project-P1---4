using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;

namespace _2201_Robot_Car_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            var StudentList = DataAccess.GetClasses();
            return View(StudentList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tutorial()
        {
            return View();
        }

        public IActionResult Student()
        {
            string studentid = HttpContext.Session.GetString("Sid");
            int id = int.Parse(studentid);
            var student = DataAccess.getstudentInfo(id);
            HttpContext.Session.SetString("StudentClass", student.Class);
            HttpContext.Session.SetString("StudentName", student.StudentName);
            //return RedirectToAction("Student");
            return View(student);
        }

        public IActionResult Challenge()
        {
            return View();
        }
        

        public IActionResult EditMap()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            return View();
        }

        public IActionResult StudentResult()
        {
            return View();
        }

        public IActionResult loadingPage()
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