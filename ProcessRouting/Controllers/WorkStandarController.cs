using Microsoft.AspNetCore.Mvc;
using WorkStandar.Data;


namespace WorkStandar.Controllers
{
    public class WorkStandarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormCreateData()
        {
            return View();
        }
        public IActionResult FormUpdateData(int id)
        {

            return View();
        }
    }
}
