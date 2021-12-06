using Microsoft.AspNetCore.Mvc;

namespace _2201_Robot_Car_Website.Models
{
    public class ParentModel : Controller
    {
        public command command { get; set; }
        public Map Map { get; set; }
    }
}
