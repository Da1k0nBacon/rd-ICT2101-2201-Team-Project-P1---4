using _2201_Robot_Car_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _2201_Robot_Car_Website.Data;

namespace _2201_Robot_Car_Website.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult LoginMode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GoStudent(string Sid)
        {
            HttpContext.Session.SetString("Sid", Sid);
            System.Diagnostics.Debug.WriteLine(HttpContext.Session.GetString("Sid"));
            
            return RedirectToAction("Student","Home");
        }

    }
}
