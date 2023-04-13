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

            modelBuilder.Entity<Generales_Departamentos>().HasIndex(c => c.Descripcion).IsUnique();
            modelBuilder.Entity<Generales_Empleados>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Generales_Empresas>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Generales_Sucursales>().HasIndex(c => c.Nombre).IsUnique();

            modelBuilder.Entity<Clientes>().HasIndex(c => c.RNC).IsUnique();
            modelBuilder.Entity<Clientes_Clasificacion>().HasIndex(c => c.Descripcion).IsUnique();

            modelBuilder.Entity<Tickets_Clasificacion>().HasIndex(c => c.Descripcion).IsUnique();
        }

        //GENERALES
        public DbSet<Generales_Departamentos> Generales_Departamentos { get; set; }
        public DbSet<Generales_Empleados> Generales_Empleados { get; set; }
        public DbSet<Generales_Empresas> Generales_Empresas { get; set; }
        public DbSet<Generales_Sucursales> Generales_Sucursales { get; set; }

        //Clientes
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Clientes_Clasificacion> Clientes_Clasificaciones { get; set; }
        public DbSet<Clientes_Contactos> Clientes_Contactos { get; set; }

        //Tickets
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Tickets_Clasificacion> Tickets_Clasificaciones { get; set; }
    }
}
