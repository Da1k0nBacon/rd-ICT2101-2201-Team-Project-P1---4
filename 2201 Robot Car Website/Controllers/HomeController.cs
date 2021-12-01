﻿using _2201_Robot_Car_Website.Models;
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
            return View();
        }

        public IActionResult StudentResult()
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