using Microsoft.EntityFrameworkCore;
using MachineHazard.Data;
using MachineHazard.Models;

namespace MachineHazard.Data
{
    public class MachineDbContext : DbContext
    {
        public MachineDbContext(DbContextOptions<MachineDbContext> options) : base(options)
        {
            try
            {
                Database.CanConnect(); // Memeriksa koneksi ke database
                Console.WriteLine("Database connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                throw;
            }
        }
        public DbSet<MachineHazardModel> machineMasterList { get; set; }
    }
}

