using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;
using System.Data;
using System.Text.Json;

namespace _2201_Robot_Car_Website.Controllers
{
    public class HomeController : Controller
    {
        Student context = new Student();
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
            return View();
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
            var StudentList = DataAccess.GetRobotData();
            return View(StudentList);
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

        //[HttpPost]
        //public ActionResult getRobot(Student sClass)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                (Student sClass)
        //{
        //    context.Students.Add(sClass);
        //    context.SaveChanges();
        //    string message = "SUCCESS";
        //    return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        //}

        [HttpPost]
        public ActionResult getRobot([FromBody] Student sClass)
        {
            string message = sClass.sClass;

            var StudentList = DataAccess.GetRobotDataTest(message);
            

            return Json(JsonSerializer.Serialize(StudentList));
        }

        [HttpGet]
        public ActionResult getStudent()
        {
            List<Student> students = new List<Student>();
            students = context.Students.ToList();
            //return Json(students, JsonRequestBehavior.AllowGet);
            return Json(students);
        }

    }
}