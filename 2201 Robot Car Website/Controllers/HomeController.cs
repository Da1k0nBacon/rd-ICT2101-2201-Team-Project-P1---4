using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;
using Newtonsoft.Json;

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
            var CommandHistList = DataAccess.LoadCommandHist();
            return View(CommandHistList);
        }

        public JsonResult SendChallengeData(string cmdSeqList)
        {
            var jsonList = JsonConvert.DeserializeObject<dynamic>(cmdSeqList);

            List<command> cmdList = new List<command>();
            foreach (var jsonItem in jsonList)
            {
                command cmd = new command();
                cmd.Direction = jsonItem.Direction;
                cmd.Student_Sid = jsonItem.Student_Sid;
                cmd.OrderNum = jsonItem.OrderNum;
                cmd.Mapdata_Mid = jsonItem.Mapdata_Mid;
                cmd.CommandSeq_id = jsonItem.CommandSeq_id;
                cmdList.Add(cmd);
            }
            DataAccess.SaveCommandHistory(cmdList);

            return Json(jsonList);

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