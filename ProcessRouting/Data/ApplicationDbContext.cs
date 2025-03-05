using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProcessRouting.Models;

namespace ProcessRouting.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
        public DbSet<ProcessRoutingModel> ProcessRoutings { get; set; }
    }
}
