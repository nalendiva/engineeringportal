using Microsoft.AspNetCore.Mvc;

namespace ProcessRouting.Controllers
{
    public class MachineHazardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateData() {
            return View();
        }
    }
}
