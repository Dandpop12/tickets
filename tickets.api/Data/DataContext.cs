using tickets.shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tickets.api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Generales_Empresas>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Generales_Sucursales>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Generales_Departamentos>().HasIndex(c => c.Descripcion).IsUnique();
        }

        //GENERALES
        public DbSet<Generales_Empresas> Generales_Empresas { get; set; }
        public DbSet<Generales_Sucursales> Generales_Sucursales { get; set; }
        public DbSet<Generales_Departamentos> Generales_Departamentos { get; set; }
    }
}
