﻿using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;
using System.Data;
using System.Text.Json;
using Newtonsoft.Json;


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
            var CommandHistList = DataAccess.LoadCommandHist();
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

        public IActionResult storage()
        {
            string[] text = System.IO.File.ReadAllLines("wwwroot/sample.txt");
            ViewBag.Data = text;
            return View();
        }
        public IActionResult DataFromMSP()
        {

            return View();
        }
       

        [HttpPost]
        public ActionResult getRobot(string sClass)
        {
            string message = sClass;

            var StudentList = DataAccess.GetRobotDataTest(message);

            //Teacher(message);
            //return Json(JsonSerializer.Serialize(StudentList));
            return PartialView("_RobotData", StudentList);
            //return Json(new {StudentList = StudentList});

        }



        [HttpGet]
        public ActionResult getStudent()
        {
            List<Student> students = new List<Student>();
            students = context.Students.ToList();
            //return Json(students, JsonRequestBehavior.AllowGet);
            return Json(students);
        }

        public ActionResult RenderRobotData()
        {
            return PartialView("_RobotData");
        }

    }
}