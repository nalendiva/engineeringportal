using Microsoft.AspNetCore.Mvc;
using ProcessRouting.Data;

namespace ProcessRouting.Controllers
{
    public class ProcessRoutingController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProcessRoutingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormCreateData()
        {
            return View();
        }
    }
}
