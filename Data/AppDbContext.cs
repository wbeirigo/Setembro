using Microsoft.EntityFrameworkCore;
using CarService.Models;

namespace CarService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Car> Car { get; set; }
    }
}