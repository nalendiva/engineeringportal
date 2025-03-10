using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkStandar.Data;
using WorkStandar.Models;

namespace WorkStandar.Controllers
{
    public class WorkStandarApiController : Controller
    {
        private readonly  WorkStandarDbContext _context;

        public WorkStandarApiController(WorkStandarDbContext context)
        {
            _context = context;
        }


        [HttpPost("WorkStandar/CreateData")]
        public async Task<IActionResult> CreateData([FromBody] WorkStandarModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Data tidak valid" });
            }

            _context.workStandardMasterlist.Add(model);
            await _context.SaveChangesAsync();
            return Json(new { message = "Data berhasil ditambahkan", data = model });
        }


        [HttpGet("WorkStandar/ReadData")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _context.workStandardMasterlist.ToListAsync();
                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(500, new { message = "Terjadi kesalahan", error = ex.Message });
            }

        }

    }
}
