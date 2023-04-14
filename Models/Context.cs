using Microsoft.EntityFrameworkCore;

namespace Departman_Core.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BATIN-PC\\SQLEXPRESS; database=BirimDBB;integrated security=true;");

        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
