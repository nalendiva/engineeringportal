using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessRouting.Data;
using ProcessRouting.Models;

namespace ProcessRouting.Controllers
{
    public class ProcessRoutingApiController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProcessRoutingApiController(ApplicationDbContext context)
        {
            _context = context;
        }




        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("/CreateData")]
        public async Task<IActionResult> CreateData([FromBody] ProcessRoutingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Data tidak valid" });
            }

            _context.ProcessRoutings.Add(model);
            await _context.SaveChangesAsync();
            return Json(new { message = "Data berhasil ditambahkan", data = model });
        }


        [HttpGet("/ReadData")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.ProcessRoutings.ToListAsync();
            return Json(data);
        }


    }
}
