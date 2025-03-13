using System.ComponentModel.DataAnnotations;
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

        [HttpPost("ProcessRouting/CreateData")]
        public async Task<IActionResult> CreateData([FromForm] ProcessRoutingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Data tidak valid" });
            }
            // Variabel untuk menyimpan nama file dan file itu sendiri
            string? fileName = null; // Variabel untuk menyimpan nama file
            string? filePath = null; // Variabel untuk menyimpan path lengkap file



            // Proses upload file jika ada
            var uploadedFile = Request.Form.Files.FirstOrDefault(f => f.Name == "processInstruction"); // Ambil file dari request
            if (uploadedFile != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Simpan file dengan nama unik (misalnya GUID)
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadedFile.FileName);
                filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

            }
            // Simpan ke database menggunakan model asli
            var newData = new ProcessRoutingModel
            {
                processType = model.processType,
                opNumber = model.opNumber,
                workcenter = model.workcenter,
                processDescriptionShort = model.processDescriptionShort,
                processDescriptionLong = model.processDescriptionLong,
                processSpec = model.processSpec,
                processInstruction = fileName, // Simpan nama file saja
                checkingChart = model.checkingChart,
                kc = model.kc,
                fixture = model.fixture,
                notes = model.notes
            };


            _context.ProcessRoutings.Add(newData);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data berhasil ditambahkan", fileUploaded = fileName, data = newData });
        }


        [HttpGet("ProcessRouting/ReadData")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.ProcessRoutings.ToListAsync();
            return Json(data);
        }

        [HttpPut("ProcessRouting/UpdateData/{id}")]
        public async Task<IActionResult> UpdateData(int id, [FromBody] ProcessRoutingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Data tidak valid" });
            }

            var existingData = await _context.ProcessRoutings.FindAsync(id);
            if (existingData == null)
            {
                return NotFound(new { message = "Data tidak ditemukan" });
            }

            existingData.processType = model.processType; 
            existingData.opNumber = model.opNumber;
            existingData.workcenter = model.workcenter;
            existingData.processDescriptionShort = model.processDescriptionShort;
            existingData.processDescriptionLong = model.processDescriptionLong;
            existingData.processSpec = model.processSpec;
            existingData.processInstruction = model.processInstruction;
            existingData.checkingChart = model.checkingChart;
            existingData.kc = model.kc;
            existingData.fixture = model.fixture;
            existingData.notes = model.notes;


            await _context.SaveChangesAsync();
            return Json(new { message = "Data berhasil diperbarui", data = existingData });
        }

        [HttpDelete("ProcessRouting/DeleteData/{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            try
            {
                var data = await _context.ProcessRoutings.FirstOrDefaultAsync(p => p.id == id);
                if (data == null)
                {
                    return Json(new { success = false, message = "Data tidak ditemukan" });
                }

                _context.ProcessRoutings.Remove(data);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Data berhasil dihapus" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Terjadi kesalahan: {ex.Message}" });
            }
        }

        [HttpGet("ProcessRouting/GetID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _context.ProcessRoutings.FirstOrDefaultAsync(p => p.id == id);
                if (data == null)
                {
                    return Json(new { success = false, message = "Data tidak ditemukan" });
                }

                return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Terjadi kesalahan: {ex.Message}" });
            }
        }

    }
}
