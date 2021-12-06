using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;

namespace _2201_Robot_Car_Website.Controllers
{
    public class Login : Controller
    {
        private readonly ILogger<Login> _logger;

        public Login(ILogger<Login> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult LoginMode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginMode(Student student)
        {
            //need edit
            return RedirectToAction("Student", "Home");

            return View();
        }


    }
}
