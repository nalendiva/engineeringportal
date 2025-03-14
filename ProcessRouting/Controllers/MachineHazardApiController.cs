using MachineHazard.Data;
using MachineHazard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineHazard.Controllers
{
    public class MachineHazardApiController : Controller
    {
        private readonly MachineDbContext _context;

        public MachineHazardApiController(MachineDbContext context)
        {
            _context = context;
        }


        [HttpGet("Machine/ReadData")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.machineMasterList.ToListAsync();
            return Json(data);
        }

        [HttpPost("Machine/CreateData")]
        public async Task<IActionResult> CreateData([FromForm] MachineHazardModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Data tidak valid" });
            }
            string? fileName = null;
            string? filePath = null;

            var uploadedFile = Request.Form.Files.FirstOrDefault(f => f.Name == "filemachine");
            if (uploadedFile != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);
                filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

            }

            var newData = new MachineHazardModel
            {
                machine = model.machine,
                filemachine = fileName,
                rev = model.rev,
                status = model.status,
            };


            _context.machineMasterList.Add(newData);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data berhasil ditambahkan", fileUploaded = fileName, data = newData });
        }

    }
}
