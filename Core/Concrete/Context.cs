using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=OSMAN; database=case; integrated security=true; TrustServerCertificate=true");
        }
        public DbSet<Personel> Personeller { get; set; }
    }
}
