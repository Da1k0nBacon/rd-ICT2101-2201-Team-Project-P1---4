using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;
using System.Data;
using System.Text.Json;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;


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

            var CommandHistList = DataAccess.LoadCommandHist(int.Parse(HttpContext.Session.GetString("Sid")));
            ViewData["newSeqID"] = DataAccess.getNewSeqID();

            
            return View(CommandHistList);
        }


        public JsonResult SendChallengeData(string cmdSeqList)
        {
            var jsonList = JsonConvert.DeserializeObject<dynamic>(cmdSeqList);
            var commands = new List<string>();
            List<command> cmdList = new List<command>();
            foreach (var jsonItem in jsonList)
            {
                command cmd = new command();
                cmd.Direction = jsonItem.Direction;
                commands.Add(cmd.Direction);
                cmd.Student_Sid = jsonItem.Student_Sid;
                cmd.OrderNum = jsonItem.OrderNum;
                cmd.Mapdata_Mid = jsonItem.Mapdata_Mid;
                cmd.CommandSeq_id = jsonItem.CommandSeq_id;
                cmdList.Add(cmd);
            }
            string allCommand = string.Join(",", commands);
            allCommand = "@" + allCommand + ",";
            FileInfo fi = new FileInfo(@"wwwroot/sample.txt");
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.Write(allCommand);
            }
            //DataAccess.SaveCommandHistory(cmdList);


            return Json(jsonList);

        }
        public IActionResult storage()
        {
            string[] text = System.IO.File.ReadAllLines("wwwroot/sample.txt");
            ViewBag.Data = text;
            return View();
        }

        public IActionResult EditMap()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            string teacherId = HttpContext.Session.GetString("Tid");
            string pw = HttpContext.Session.GetString("pw");
            var teacher = DataAccess.getTeacherInfo(int.Parse(teacherId),pw);
            return View(teacher);
        }

        public IActionResult StudentResult()
        {
            var StudentList = DataAccess.GetStudData();
            return View(StudentList);
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


        [HttpPost]
        public ActionResult getStudData(string sClass)
        {
            string message = sClass;

            var StudentList = DataAccess.GetStudDataTest(message);

            return PartialView("_StudData", StudentList);

        }

        public ActionResult RenderStudData()
        {
            return PartialView("_StudData");
        }

        public IActionResult StudentDetails(int id)
        {
            var studentCommandHist = DataAccess.getStudentCommandHist(id);
            return View(studentCommandHist);
        }


        // Send Map Data
        [HttpPost]
        public JsonResult SendMapData(string mapData)
        {
            var mapDat = JsonConvert.DeserializeObject<dynamic>(mapData);
            int teacherId = int.Parse(HttpContext.Session.GetString("Tid"));
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=robotwebsitedb; password=root;port=3306"))
            {
                string Query = "INSERT INTO mapdata (Mid, Grid1,Grid2,Grid3,Grid4,Grid5,Grid6,Grid7,Grid8,Grid9,Grid10,Grid11,Grid12,Grid13,Grid14,Grid15,Grid16,Teacher_TID)" +
                    "VALUES('1','" + mapDat[0]["Grid1"] + "','" + mapDat[0]["Grid2"] + "','" + mapDat[0]["Grid3"] + "','" + mapDat[0]["Grid4"] + "','" + mapDat[0]["Grid5"]
                    + "','" + mapDat[0]["Grid6"] + "','" + mapDat[0]["Grid7"] + "','" + mapDat[0]["Grid8"] + "','" + mapDat[0]["Grid9"] + "','" + mapDat[0]["Grid10"]
                    + "','" + mapDat[0]["Grid11"] + "','" + mapDat[0]["Grid12"] + "','" + mapDat[0]["Grid13"] + "','" + mapDat[0]["Grid14"] + "','" + mapDat[0]["Grid15"]
                    + "','" + mapDat[0]["Grid16"] + "','" + teacherId + "')";

                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                con.Close();
            }


            return Json(mapDat);
        }

    }
}