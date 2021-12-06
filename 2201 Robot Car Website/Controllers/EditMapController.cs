using Microsoft.AspNetCore.Mvc;
using _2201_Robot_Car_Website.Models;
using Newtonsoft.Json;

namespace _2201_Robot_Car_Website.Controllers
{
    public class EditMapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(string Submit,Map map)
        {

            return null;
        }

        [HttpPost]
        public JsonResult SendMapData(string mapData)
        {
            var mapDat = JsonConvert.DeserializeObject<dynamic>(mapData);

            return Json(mapDat);
        }
    }
}
