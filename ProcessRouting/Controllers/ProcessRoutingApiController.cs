using Microsoft.AspNetCore.Mvc;
using ProcessRouting.Data;

namespace ProcessRouting.Controllers
{
    public class ProcessRoutingApiController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProcessRoutingApiController (ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
