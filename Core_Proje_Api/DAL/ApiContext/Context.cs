using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FATMA-EREN\\SQLEXPRESS;database=CoreProjeDbb2;integrated security=true");
        }

        public DbSet<Catogary> Catogaries { get; set; }
    }
}
