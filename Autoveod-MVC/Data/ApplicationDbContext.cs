using Microsoft.EntityFrameworkCore;

namespace Autoveod_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Autoveod_MVC.Models.Autovedu> Autoveod { get; set; }
    }
}