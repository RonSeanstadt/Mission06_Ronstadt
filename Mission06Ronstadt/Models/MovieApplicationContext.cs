using Microsoft.EntityFrameworkCore;

namespace Mission06Ronstadt.Models
{
    public class MovieApplicationContext : DbContext // Liaison from the app to the database
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options) // Constructor
        {

        }

        public DbSet<Application> Applications { get; set; }
    }
}
