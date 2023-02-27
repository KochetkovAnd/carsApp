using carsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace carsApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
