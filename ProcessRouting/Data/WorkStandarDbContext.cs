using Microsoft.EntityFrameworkCore;
using WorkStandar.Models;

namespace WorkStandar.Data
{
    public class WorkStandarDbContext : DbContext
    {
        public WorkStandarDbContext(DbContextOptions<WorkStandarDbContext> options) : base(options)
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
    public DbSet<WorkStandarModel> workStandardMasterlist { get; set; }
    }
}
